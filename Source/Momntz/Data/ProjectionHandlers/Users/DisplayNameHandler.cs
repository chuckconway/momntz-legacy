using Hypersonic;
using Momntz.Data.Projections.Users;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class DisplayNameHandler : IProjectionHandler<string, DisplayName>
    {
        private readonly ISession _session;

        public DisplayNameHandler(ISession session)
        {
            _session = session;
        }

        public DisplayName Execute(string args)
        {
          return  _session.Query<DisplayName>("GetUserView")
                .Where(string.Format("Username = '{0}'", args))
                .Single();
        }
    }
}
