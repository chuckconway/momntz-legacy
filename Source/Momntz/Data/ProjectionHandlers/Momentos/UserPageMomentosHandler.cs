using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class UserPageMomentosHandler : BaseMomentoHandler, IProjectionHandler<string, List<MomentoWithMedia>>
    {
        public UserPageMomentosHandler(IMomntzSession session, ISettings settings) : base(session, settings) { }

        public List<MomentoWithMedia> Execute(string username)
        {
            List<MomentoWithMedia> homepages = new List<MomentoWithMedia>();

                var momentos = Session
                    .Session
                    .Database
                    .List<Momento, object>("[dbo].[Momento_RetrieveRandom20ByUser]", new { username });
                GetMedia(momentos, homepages);

            return homepages;
        }
    }
}
