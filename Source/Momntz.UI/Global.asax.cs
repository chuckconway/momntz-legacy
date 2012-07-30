
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Chucksoft.Core.Services;
using Hypersonic;
using Hypersonic.Session;
using Momntz.Data.PersistIntercepters;
using Momntz.Infrastructure;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core;
using Momntz.UI.Core.Binders;
using Momntz.UI.Core.RouteHandler;
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

        /// <summary> Application start. </summary>
        protected void Application_Start()
        {
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
                x.For<ISession>().Use(SessionFactory.SqlServer(key:"sql"));
                x.For<IConfigurationService>().Use<MomntzConfiguration>();
                
                x.For<IProjectionProcessor>().Use<ProjectionProcessor>();
 
                s.TheCallingAssembly();
                s.WithDefaultConventions();

                s.ConnectImplementationsToTypesClosing(typeof(IFormHandler<>));
                s.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));

                x.For<IInjection>().Use(new StructureMapInjection());
            }));

            SqlServerSession.AddPersistIntercepter(new AuditPersistIntercepter());
            ModelBinders.Binders.Add(typeof(NewTag), new NewTagModelBinder());

            ObjectFactory.AssertConfigurationIsValid();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver());
        }
    }

    internal class StructureMapDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return ObjectFactory.TryGetInstance(serviceType);
            }

            return ObjectFactory.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
        }
    }
}