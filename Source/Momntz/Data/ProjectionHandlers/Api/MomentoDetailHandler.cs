using Momntz.Data.Projections.Api;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class MomentoDetailHandler : IProjectionHandler<int, MomentoDetail>
    {
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoDetailHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public MomentoDetailHandler(ISession session)
        {
            _session = session;

        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>MomentoDetail.</returns>
        public MomentoDetail Execute(int args)
        {
            using(var trans =_session.BeginTransaction())
            {
               MomentoDetail detail = _session.QueryOver<MomentoDetail>()
                    .Where(x => x.Id == args)
                    .SingleOrDefault();

                trans.Commit();

                return detail;
            }
        }
    }
}
