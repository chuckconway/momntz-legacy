using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Momntz.Model.Configuration;
using NHibernate;
using NUnit.Framework;

namespace Momntz.Tests
{
    [TestFixture]
    public class nHibernateTest
    {
        private ISessionFactory _sessionFactory;

        [SetUp]
        public void Setup()
        {
            _sessionFactory = CreateSessionFactory();
        }

        [Test]
        public void Settings()
        {
             IList<Setting> settings = new List<Setting>();
           using(ISession session =_sessionFactory.OpenSession())
           {
             settings =  session
                   .QueryOver<Setting>()
                   .List();
           }

           Assert.Greater(settings.Count,  0);

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
