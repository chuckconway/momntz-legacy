using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Users;
using Momntz.Data.Schema;

using NHibernate;
using NHibernate.Criterion;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class GetActiveUsersHandler : IProjectionHandler<object, IList<ActiveUsername>>
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="session">The session.</param>
        public GetActiveUsersHandler(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary> Executes. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        public IList<ActiveUsername> Execute(object args)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                var items = session.QueryOver<User>()
                    .Where(Restrictions.Or(Restrictions.Eq("UserStatus", UserStatus.Active), Restrictions.Eq("UserStatus", UserStatus.Ghost)))
                    .List()
                    .Select(r => new ActiveUsername() {Username = r.Username})
                    .ToList();

                trans.Commit();

                return items;
            }
        }
    }
}
