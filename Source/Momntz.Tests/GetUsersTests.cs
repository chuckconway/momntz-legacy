using Hypersonic;
using Hypersonic.Session;
using Momntz.Data.Projections.Users;
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
            //ISession session = SessionFactory.SqlServer();
            //var list = session.Query<GetActiveUsers, User>().Where("UserStatus = 'Active'").List();
        }
    }
}
