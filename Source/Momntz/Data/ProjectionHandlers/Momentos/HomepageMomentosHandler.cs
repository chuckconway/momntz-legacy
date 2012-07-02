using System.Collections.Generic;
using System.Data;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class HomepageMomentosHandler : BaseMomentoHandler, IProjectionHandler<object, IList<MomentoWithMedia>>
    {
        public HomepageMomentosHandler(IMomntzSession session, ISettings settings) : base(session, settings) { }

        public IList<MomentoWithMedia> Execute(object args)
        {
            var homepages = new List<MomentoWithMedia>();

                Session.Session.Database.CommandType = CommandType.StoredProcedure;
                var momentos = Session.Session.Database.List<Momento>("[dbo].[Momento_RetrieveRandom20]");

                GetMedia(momentos, homepages);

            return homepages;
        }
    }
}
