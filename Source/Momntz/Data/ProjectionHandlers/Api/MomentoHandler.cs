using Momntz.Data.Schema;

using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class MomentoHandler : IProjectionHandler<int, Momento>
    {
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public MomentoHandler(ISession session)
        {
            _session = session;

        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>MomentoDetail.</returns>
        public Momento Execute(int args)
        {
            using(var trans =_session.BeginTransaction())
            {
               var detail = _session.QueryOver<Momento>()
                    .Where(x => x.Id == args)
                    .SingleOrDefault();

                trans.Commit();

                return detail;
            }
        }
    }
}
