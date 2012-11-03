using Chucksoft.Core.Services;
using Hypersonic;
using Hypersonic.Session;
using Momntz.Infrastructure;
using Momntz.UI.Core;
using StructureMap;

namespace Momntz.Tests.Setup
{
    public class DependencyInjection
    {
        /// <summary> Registers the dependency injection. </summary>
        public static void Setup()
        {
            ObjectFactory.Initialize(x => x.Scan(s =>
            {
                x.AddRegistry<MomntzRegistry>();
                x.For<IDatabase>().Use(new MsSqlDatabase());
                x.For<ISession>().Use(SessionFactory.SqlServer(key: "sql"));
                x.For<IConfigurationService>().Use<MomntzConfiguration>();

                x.For<IProjectionProcessor>().Use<ProjectionProcessor>();

                s.TheCallingAssembly();
                s.WithDefaultConventions();

                s.ConnectImplementationsToTypesClosing(typeof(IFormHandler<>));
                s.ConnectImplementationsToTypesClosing(typeof(IQueryHandler<,>));

                x.For<IInjection>().Use(new StructureMapInjection());
            }));

            ObjectFactory.AssertConfigurationIsValid();


        }
    }
}
