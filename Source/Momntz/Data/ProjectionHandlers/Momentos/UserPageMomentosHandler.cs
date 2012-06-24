using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class UserPageMomentosHandler : BaseMomentoHandler, IProjectionHandler<string, List<MomentoWithMedia>>
    {
        public UserPageMomentosHandler(ISession session, ISettings settings) : base(session, settings) { }

        public List<MomentoWithMedia> Execute(string username)
        {
            List<MomentoWithMedia> homepages = new List<MomentoWithMedia>();

            using (Session)
            {
                var momentos = Session
                    .Database
                    .List<Momento, object>("[dbo].[Momento_RetrieveRandom20ByUser]", new { username });
                GetMedia(momentos, homepages);
            }

            return homepages;
        }
    }
}
