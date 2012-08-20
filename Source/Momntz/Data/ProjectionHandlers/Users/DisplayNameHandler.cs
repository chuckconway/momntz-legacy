using Hypersonic;
using Momntz.Data.Projections.Users;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class DisplayNameHandler : IProjectionHandler<string, DisplayName>
    {
        private readonly IMomntzSession _session;

        public DisplayNameHandler(IMomntzSession session)
        {
            _session = session;
        }

        public DisplayName Execute(string args)
        {
          return  _session.Session.Query<DisplayName>("GetUserView")
                .Where(string.Format("Username = '{0}'", args))
                .Single();
        }
    }
}
