using System.Collections.Generic;
using System.IO;
using System.Linq;
using FakeItEasy;
using Hypersonic;
using Momntz.Data.CommandHandlers.Momentos;
using Momntz.Data.CommandHandlers.Users;
using Momntz.Data.Commands.Momentos;
using Momntz.Data.Commands.Users;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Infrastructure;
using Momntz.Infrastructure.Processors;
using Momntz.Model;
using Momntz.Model.Configuration;
using Momntz.Tests.Setup;
using NUnit.Framework;

namespace Momntz.Tests
{
    [TestFixture]
    public class TagControllerTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            DependencyInjection.Setup();
        }

        public List<CreateMomentoMediaCommand> GetDummyMedia(string username)
        {
            var list = new List<CreateMomentoMediaCommand>()
                           {
                               new CreateMomentoMediaCommand(Path.GetRandomFileName(), Path.GetRandomFileName(),
                                                             "http://" + Path.GetRandomFileName(), 10000, username,
                                                             MediaType.OriginalImage),
                               new CreateMomentoMediaCommand(Path.GetRandomFileName(), Path.GetRandomFileName(),
                                                             "http://" + Path.GetRandomFileName(), 10000, username,
                                                             MediaType.MediumImage),
                              new CreateMomentoMediaCommand(Path.GetRandomFileName(), Path.GetRandomFileName(),
                                                             "http://" + Path.GetRandomFileName(), 10000, username,
                                                             MediaType.SmallImage),
                           };


            return list;
        }

        [Test]
        public void Tag_CreateTag_TagIsCreated()
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            string username = Path.GetRandomFileName();
            //Create User
            CreateUserCommand createUser = new CreateUserCommand(username, username, "contact@cconway.com", "Test Name", "Chuck", "Conway", "secret");
            CreateUserCommandHandler userCommand = new CreateUserCommandHandler(new MsSqlDatabase(), new Crypto());

            userCommand.Execute(createUser);
            var media = GetDummyMedia(username);

            //Create Add Momento
            CreateMomentoCommand createMomento = new CreateMomentoCommand(username, media);

            MvcApplication.ConfigureAutoMapper();
            CreateMomentoCommandHandler momentoCommandHandler = new CreateMomentoCommandHandler(nHibernateTest.CreateSessionFactory().OpenSession(), new Mapper());
            momentoCommandHandler.Execute(createMomento);

            var setting = A.Fake<ISettings>();
            UserPageMomentosHandler handler = new UserPageMomentosHandler(new MsSqlDatabase(), setting);


            var list = handler.Execute(username);
            var momento = list.First();

            //Tag the Photo
            var controller = new TagsController(new ProjectionProcessor(new StructureMapInjection()),new CommandProcessor(new StructureMapInjection()));
            string name = Path.GetRandomFileName();
            NewTag tag = new NewTag()
                             {
                                 Height = 20,
                                 Left = 30,
                                 MomentoId = momento.Momento.Id,
                                 Name = name,
                                 Width = 12,
                                 Top = 20,
                                 Username = username
                             };

            controller.InternalAddTag(tag, username);

            string name1 = Path.GetRandomFileName();
            NewTag tag1 = new NewTag()
            {
                Height = 20,
                Left = 30,
                MomentoId = momento.Momento.Id,
                Name = name1,
                Width = 12,
                Top = 20,
                Username = username
            };

            controller.InternalAddTag(tag1, username);


            string name2 = Path.GetRandomFileName();
            NewTag tag2 = new NewTag()
            {
                Height = 20,
                Left = 30,
                MomentoId = momento.Momento.Id,
                Name = name2,
                Width = 12,
                Top = 20,
                Username = username
            };

            controller.InternalAddTag(tag2, username);

        }
    }
}
