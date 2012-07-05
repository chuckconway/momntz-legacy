using Momntz.Data.Projections.Api;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class MomentoDetailHandler : IProjectionHandler<int, MomentoDetail>
    {
        private readonly IMomntzSession _session;

        public MomentoDetailHandler(IMomntzSession session)
        {
            _session = session;
        }

        public MomentoDetail Execute(int args)
        {
           return _session.Session
                .Query<MomentoDetail>()
                .Where(string.Format("Id = {0}", args))
                .Single();
        }
    }
}
