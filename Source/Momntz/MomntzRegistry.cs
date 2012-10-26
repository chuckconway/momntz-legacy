using Chucksoft.Core.Services;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hypersonic.Session;
using Momntz.Data;
using Momntz.Data.CommandHandlers;
using Momntz.Data.ProjectionHandlers;
using Momntz.Infrastructure;
using Momntz.Model.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using StructureMap.Configuration.DSL;

namespace Momntz
{
    public class MomntzRegistry : Registry 
    {
        public MomntzRegistry()
        {
            For<ISessionFactory>().Use(CreateSessionFactory());
            Scan(
                s =>
                    {
                        s.TheCallingAssembly();
                        s.WithDefaultConventions();
                        s.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<>));
                        s.ConnectImplementationsToTypesClosing(typeof(IProjectionHandler<,>));
                    });
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
