using Hypersonic;
using Hypersonic.Session;
using Momntz.Model;
using NUnit.Framework;

namespace Momntz.Tests
{
    [TestFixture]
    public class GetUsersTests
    {
        [Test]
        public void GetUsersTest_GetAllUsers_AllUsersAreReturned()
        {
            ISession session = SessionFactory.SqlServer();
           var user = session.Query<User>(new[] {"Username"})
                .List();
        }
    }
}
