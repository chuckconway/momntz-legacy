using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hypersonic;

using Momntz.Infrastructure;
using Momntz.Infrastructure.Configuration;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Core;
using NHibernate;
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
                x.For<NHibernate.ISession>().Use(CreateSessionFactory().OpenSession);
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
}
