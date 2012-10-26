using System.Linq;

using Momntz.Data.Projections.Users;
using Momntz.Model;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Users
{
    public class DisplayNameHandler : IProjectionHandler<string, DisplayName>
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayNameHandler" /> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public DisplayNameHandler(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>DisplayName.</returns>
        public DisplayName Execute(string args)
        {
            using(ISession session = _sessionFactory.OpenSession())
            {
              var item =  session.QueryOver<User>()
                    .Where(x => x.Username == args)
                    .SingleOrDefault();

                return new DisplayName() {Fullname = item.FullName};
            }
        }
    }
}
