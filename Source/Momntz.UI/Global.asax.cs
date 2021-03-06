﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ChuckConway.Cloud.Queue;
using ChuckConway.Cloud.Storage;
using ChuckConway.Cryptography;
using Hypersonic;
using Momntz.Core.Contants;
using Momntz.Core.TypeConverters;
using Momntz.Data.Repositories.Momentos.Parameters;
using Momntz.Data.Repositories.Users.Parameters;
using Momntz.Data.Schema;
using Momntz.Infrastructure;
using Momntz.Infrastructure.Configuration;
using Momntz.Infrastructure.Instrumentation.Logging;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core;
using Momntz.UI.Core.Binders;
using NHibernate;
using StructureMap;

namespace Momntz.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterDependencyInjection();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            
        }

                /// <summary> Registers the global filters described by filters. </summary>
        /// <param name="filters"> The filters. </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Application_Error(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;

            var ex = context.Server.GetLastError();
            if (ex != null)
            {
                int statusCode = -1;

                var exception = ex as HttpException;
                if (exception != null)
                {
                    statusCode = exception.GetHttpCode();
                }

                var log = ObjectFactory.GetInstance<ILog>();
                log.Exception(ex, statusCode.ToString(CultureInfo.InvariantCulture), "Caught in the Global.asax");
            }
        }


        /// <summary>
        /// Application_s the end request.
        /// </summary>
        protected void Application_EndRequest()
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        /// <summary> Registers the dependency injection. </summary>
        private void RegisterDependencyInjection()
        {
            var settings = MomntzConfiguration.GetSettings();
            SetLogging(settings);

            ObjectFactory.Initialize(x => x.Scan(s =>
            {
                x.AddRegistry<MomntzRegistry>();
                
                x.For<IDatabase>().Use(new MsSqlDatabase());
                x.For<ApplicationSettings>().Use(settings);

                x.For<ICrypto>().Use<Crypto>();
                x.For<ILog>().Use<Log>();
                x.For<IConfigurationService>().Use<MomntzConfiguration>();
                x.For<ISessionFactory>().Singleton().Use(Database.CreateSessionFactory);
                x.For<NHibernate.ISession>().HttpContextScoped().Use(r=> r.GetInstance<ISessionFactory>().OpenSession());
                x.For<IStorage>().Use<AzureStorage>()
                 .Ctor<string>("cloudUrl")
                 .Is(settings.CloudUrl)
                 .Ctor<string>("cloudAccount")
                 .Is(settings.CloudAccount)
                 .Ctor<string>("cloudKey")
                 .Is(settings.CloudKey);

                x.For<IQueue>().Use<AzureQueue>()
                    .Ctor<string>("connectionString")
                 .Is(settings.ServiceBusEndpoint);
 
                s.TheCallingAssembly();
                s.WithDefaultConventions();

                s.ConnectImplementationsToTypesClosing(typeof(IFormHandler<>));
                s.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));

                x.For<IInjection>().Use(new StructureMapInjection());
            }));

            ModelBinders.Binders.Add(typeof(NewTag), new NewTagModelBinder());
            ModelBinders.Binders.Add(typeof(UsernameAndPassword), new UsernameAndPasswordModelBinder());

            ObjectFactory.AssertConfigurationIsValid();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver());

            ConfigureAutoMapper();
        }

        private static void SetLogging(ApplicationSettings settings)
        {
            //Set global logger, use cloud the UI
            settings.LoggerType = LoggingConstants.Cloud;
            settings.RestLoggingEndpoint = settings.UILoggingEndpoint;
        }

        /// <summary>
        /// Configures the aut do mapper.
        /// </summary>
        public static void ConfigureAutoMapper()
        {
            AutoMapper.Mapper.Initialize(c=> c.CreateMap<CreateMomentoParameters, Momento>().ConvertUsing(new CreateMomentoCommandToMomentoConverter()));
        }

    }

    internal class StructureMapDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Resolves singly registered services that support arbitrary object creation.
        /// </summary>
        /// <param name="serviceType">The type of the requested service or object.</param>
        /// <returns>The requested service or object.</returns>
        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return ObjectFactory.TryGetInstance(serviceType);
            }

            return ObjectFactory.GetInstance(serviceType);
        }

        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>The requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
        }
    }
    }
