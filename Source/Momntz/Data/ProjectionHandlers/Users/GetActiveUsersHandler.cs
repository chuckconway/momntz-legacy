using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Users;
using Momntz.Model;
using NHibernate;
using NHibernate.Criterion;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class GetActiveUsersHandler : IProjectionHandler<object, IList<ActiveUsername>>
    {
        private readonly ISession _session;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="session">The session.</param>
        public GetActiveUsersHandler(ISession session)
        {
            _session = session;
        }

        /// <summary> Executes. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        public IList<ActiveUsername> Execute(object args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<User>()
                    .Where(Restrictions.Or(Restrictions.Eq("UserStatus", UserStatus.Active), Restrictions.Eq("UserStatus", UserStatus.Ghost)))
                    .List()
                    .Select(r => new ActiveUsername() {Username = r.Username})
                    .ToList();

                trans.Commit();

                return items;

                //return  _session.Session
                //        .Query<ActiveUsername, User>()
                //        .Where("UserStatus = " + (int)UserStatus.Active + " OR UserStatus = " + (int)UserStatus.Ghost)
                //        .List();
            }
        }
    }
}
