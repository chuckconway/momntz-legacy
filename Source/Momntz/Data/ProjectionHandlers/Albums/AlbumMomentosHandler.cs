using System.Collections.Generic;
using Hypersonic;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AlbumMomentosHandler : BaseMomentoHandler, IProjectionHandler<AlbumMomentosParameters, List<MomentoWithMedia>>
    {
        private readonly IDatabase _database;

        public AlbumMomentosHandler(IDatabase database, ISettings settings): base(database, settings)
        {
            _database = database;
        }

        public List<MomentoWithMedia> Execute(AlbumMomentosParameters args)
        {
            var homepages = new List<MomentoWithMedia>();
            var momentos = _database.List<Momento, object>("TagAlbum_GetMomentosByNameAndUsername", args);

            GetMedia(momentos, homepages);
            return homepages;
        }
    }

    public class AlbumMomentosParameters
    {
        public string Username { get; set; }

        public string Name { get; set; }
    }
}
