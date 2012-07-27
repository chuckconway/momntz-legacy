using System.Collections.Generic;
using System.Data;
using Momntz.Data.Projections.Api;

namespace Momntz.Data.ProjectionHandlers.Api
{
    public class MomentoTagHandler : IProjectionHandler<int, IList<MomentoTag>>
    {
        private readonly IMomntzSession _session;

        public MomentoTagHandler(IMomntzSession session)
        {
            _session = session;
        }

        public IList<MomentoTag> Execute(int args)
        {
            return _session.Session.Database.List<MomentoTag, object>("TagPerson_RetrieveTagsByMomentoId", new { MomentoId = args });
        }
    }
}
