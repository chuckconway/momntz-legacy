using System.Collections.Generic;
using System.Data;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Connections;
using Momntz.Infrastructure.Configuration;

namespace Momntz.Data.ProjectionHandlers.Connections
{
    public class ConnectionResultHandler : IProjectionHandler<ConnectionResultParameters, List<IGroupItem>>
    {
        private readonly IDatabase _database;
        private readonly ISettings _settings;


        public ConnectionResultHandler(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        public List<IGroupItem> Execute(ConnectionResultParameters args)
        {
            _database.ConnectionStringName = "sql";
            _database.CommandType = CommandType.StoredProcedure;
            var items = new List<IGroupItem>();

            var results = _database.List<ConnectionResult, object>("User_GetConnectionsByUsername", args).ToList();

            string rootUrl = _settings.CloudUrl;

            foreach (var result in results)
            {
                result.Url = string.Format("{0}/{1}", rootUrl, result.Url);
                items.Add(result);
            }

            return items;
        }
    }

    public class ConnectionResultParameters
    {
        public string Username { get; set; }
    }
}
