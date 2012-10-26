using System.Collections.Generic;
using System.Data;
using Hypersonic;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    public class HomepageMomentosHandler : BaseMomentoHandler, IProjectionHandler<object, List<MomentoWithMedia>>
    {
        private readonly IDatabase _database;

        public HomepageMomentosHandler(IDatabase database, ISettings settings)
            : base(database, settings)
        {
            _database = database;
        }

        public List<MomentoWithMedia> Execute(object args)
        {
            var homepages = new List<MomentoWithMedia>();

                var momentos = _database.List<Momento>("[dbo].[Momento_RetrieveRandom20]");

                GetMedia(momentos, homepages);

            return homepages;
        }
    }
}
