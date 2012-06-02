using System;
using System.Collections.Generic;
using Hypersonic;
using Hypersonic.Session;
using Momntz.Data.CommandHandlers.Momentos;
using Momntz.Data.Commands.Momentos;
using Momntz.Model;
using NUnit.Framework;

namespace Momntz.Tests
{
    [TestFixture]
    public class CreateMomentoCommandTests
    {
        [Test]
        public void CreateMomento_Insert_ItsCreated()
        {
            string randomUsername = Guid.NewGuid().ToString();
            string filename = Guid.NewGuid().ToString();

            CreateMomentoMediaCommand media = new CreateMomentoMediaCommand(filename, "image/jpg", "img/fdsafasfdsf.jpg", 12343, randomUsername, MediaType.Image);
            CreateMomentoCommand command = new CreateMomentoCommand(randomUsername, new List<CreateMomentoMediaCommand> { media });
            CreateMomentoCommandHandler handler = new CreateMomentoCommandHandler(SessionFactory.SqlServer());
            
            handler.Execute(command);

            ISession session = SessionFactory.SqlServer();
            var momento = session.Query<Momento>()
                              .Where(u => u.Username == randomUsername)
                              .Single();

            StringAssert.AreEqualIgnoringCase(command.Username, momento.Username);

            var momentoMedia = session.Query<MomentoMedia>()
                              .Where(u => u.Filename == filename)
                              .Single();

            StringAssert.AreEqualIgnoringCase(media.Filename, momentoMedia.Filename);
        }
    }
}
