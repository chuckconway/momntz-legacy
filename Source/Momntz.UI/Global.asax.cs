
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Chucksoft.Core.Services;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hypersonic;
using Hypersonic.Session;
using Momntz.Core.TypeConverters;
using Momntz.Data.Commands.Momentos;
using Momntz.Data.ProjectionHandlers.Users;
using Momntz.Infrastructure;
using Momntz.Model;
using Momntz.Model.Configuration;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core;
using Momntz.UI.Core.Binders;
using Momntz.UI.Core.RouteHandler;
using NHibernate;
using StructureMap;

namespace Momntz.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        /// <summary> Registers the global filters described by filters. </summary>
        /// <param name="filters"> The filters. </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary> Registers the routes described by routes. </summary>
        /// <param name="routes"> The routes. </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var route = new Route("uploader/upload.mvc", new UploadRouteHandler());
            routes.Add(route);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_EndRequest()
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }
        
        /// <summary> Application start. </summary>
        protected void Application_Start()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            RegisterDependencyInjection();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);

            BundleTable.Bundles.RegisterTemplateBundles();
        }

        /// <summary> Registers the dependency injection. </summary>
        private void RegisterDependencyInjection()
        {
            ObjectFactory.Initialize(x => x.Scan(s =>
            {
                x.AddRegistry<MomntzRegistry>();
                x.For<IDatabase>().Use(new MsSqlDatabase());
                x.For<IConfigurationService>().Use<MomntzConfiguration>();
                x.For<NHibernate.ISession>().HttpContextScoped().Use(CreateSessionFactory().OpenSession);
                x.For<IProjectionProcessor>().Use<ProjectionProcessor>();
 
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

        /// <summary>
        /// Configures the aut do mapper.
        /// </summary>
        public static void ConfigureAutoMapper()
        {
            AutoMapper.Mapper.Initialize(c=> c.CreateMap<CreateMomentoCommand, Momento>().ConvertUsing(new CreateMomentoCommandToMomentoConverter()));
        }

        /// <summary>
        /// Creates the session factory.
        /// </summary>
        /// <returns>ISessionFactory.</returns>
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c
                        .FromConnectionStringWithKey("sql")))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Setting>())
                    .BuildSessionFactory();
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