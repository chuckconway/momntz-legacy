using Momntz.Data.Projections.Users;
using Momntz.Data.Schema;

using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class DisplayNameHandler : IProjectionHandler<string, DisplayName>
    {
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayNameHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public DisplayNameHandler(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>DisplayName.</returns>
        public DisplayName Execute(string args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var item = _session.QueryOver<User>()
                                   .Where(u => u.Username == args)
                                   .SingleOrDefault();


                trans.Commit();
                return new DisplayName() {Fullname = item.FullName};
            }
        }
    }
}
