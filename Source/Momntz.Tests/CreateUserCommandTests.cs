using System.IO;
using Hypersonic;
using Hypersonic.Session;
using Momntz.Data;
using Momntz.Data.CommandHandlers.Users;
using Momntz.Data.Commands.Users;
using Momntz.Data.PersistIntercepters;
using Momntz.Model;
using NUnit.Framework;

namespace Momntz.Tests
{
    [TestFixture]
    public class CreateUserCommandTests
    {
        [Test]
        public void CreateUser_ValidData_UserIsCreated()
        {
            string username = Path.GetRandomFileName();
            CreateUserCommand command = new CreateUserCommand(username, username,
                Path.GetRandomFileName(), Path.GetRandomFileName(), Path.GetRandomFileName(), Path.GetRandomFileName());

            SqlServerSession.AddPersistIntercepter(new AuditPersistIntercepter());

            CreateUserCommandHandler handler = new CreateUserCommandHandler(new MomntzSession(SessionFactory.SqlServer(key:"sql")));
            handler.Execute(command);

            ISession session = SessionFactory.SqlServer();
            var user = session.Query<User>()
                              .Where(u => u.Username == username)
                              .Single();

            StringAssert.AreEqualIgnoringCase(command.Username, user.Username);
        }

    }
}
