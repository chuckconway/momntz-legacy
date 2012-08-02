using Momntz.Data.Projections.Api;
using System.Linq;

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
           var detail = _session.Session
                .Query<MomentoDetail>()
                .Where(string.Format("Id = {0}", args))
                .Single();

            if(detail != null)
            {
               detail.People = _session.Session
                    .Query<Person>("TagPersonView")
                    .Where("MomentoId = " + args)
                    .List().ToList();

               detail.Albums = _session.Session
                .Query<Album>("TagAlbumView")
                .Where("MomentoId = " + args)
                .List().ToList();
            }

            return detail;
        }
    }
}
