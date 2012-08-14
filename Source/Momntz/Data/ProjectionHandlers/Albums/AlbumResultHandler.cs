using System.Collections.Generic;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Albums;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AlbumResultHandler : BaseGroupItem, IProjectionHandler<AlbumResultsParameters, List<IGroupItem>>
    {
        private readonly IDatabase _database;
        private readonly ISettings _settings;

        public AlbumResultHandler(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        public List<IGroupItem> Execute(AlbumResultsParameters args)
        {
            _database.ConnectionStringName = "sql";
            var results = _database.List<AlbumResult, object>("TagAlbum_GetAlbumByUsername", args).ToList();
            return GetItems(_settings, results);
        }
    }

    public class AlbumResultsParameters
    {
        public string Username { get; set; }
    }
}
