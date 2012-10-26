using Momntz.Data.Projections.Api;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class MomentoDetailHandler : IProjectionHandler<int, MomentoDetail>
    {
        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoDetailHandler" /> class.
        /// </summary>
        /// <param name="sessionFactory">The session factory.</param>
        public MomentoDetailHandler(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>MomentoDetail.</returns>
        public MomentoDetail Execute(int args)
        {
            MomentoDetail detail;

            using(ISession session = _sessionFactory.OpenSession())
            {
               detail = session.QueryOver<MomentoDetail>()
                    .Where(x => x.Id == args)
                    .SingleOrDefault();
            }
           //var detail = _session.Session
           //     .Query<MomentoDetail>()
           //     .Where(string.Format("Id = {0}", args))
           //     .Single();

           // if(detail != null)
           // {
           //    detail.People = _session.Session
           //         .Query<Person>("TagPersonView")
           //         .Where("MomentoId = " + args)
           //         .List().ToList();

           //    detail.Albums = _session.Session
           //     .Query<Album>("TagAlbumView")
           //     .Where("MomentoId = " + args)
           //     .List().ToList();
           // }

            return detail;
        }
    }
}
