using System;
using System.IO;
using Hypersonic;
using Momntz.Data.ProjectionHandlers.Import;
using Momntz.Data.Projections.Import;
using Momntz.Infrastructure;
using Momntz.Tests.Setup;
using NUnit.Framework;
using StructureMap;
using ISession = NHibernate.ISession;

namespace Momntz.Tests
{
    [TestFixture ]
    public class ImportCreateUserTest
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            DependencyInjection.Setup();
        }

        [Test]
        public void Api_CreateNewUser_NewUserIsCreated()
        {
            string username = Path.GetRandomFileName();
            var userProjection = new GetApiUserProjectionHandler(ObjectFactory.GetInstance<ISession>(), ObjectFactory.GetInstance<IDatabase>(), ObjectFactory.GetInstance<IProjectionProcessor>());
            var result = userProjection.Execute(new GetApiUserProjection { ApiKey = new Guid("7C80C1F5-1E58-4A35-8224-07B835780A5F"), Username = username });

            StringAssert.AreEqualIgnoringCase(username, result);
        }
    }
}
