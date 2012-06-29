using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class HomepageMomentosHandler : BaseMomentoHandler, IProjectionHandler<object, IList<MomentoWithMedia>>
    {
        public HomepageMomentosHandler(ISession session, ISettings settings):base(session, settings){}

        public IList<MomentoWithMedia> Execute(object args)
        {
            List<MomentoWithMedia> homepages = new List<MomentoWithMedia>();

            using (Session)
            {
                var momentos = Session.Database.List<Momento>("[dbo].[Momento_RetrieveRandom20]");

                GetMedia(momentos, homepages);
            }

            return homepages;
        }
    }
}
