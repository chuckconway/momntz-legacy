using System.Collections.Generic;
using System.Data;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Connections;
using Momntz.Infrastructure.Configuration;

namespace Momntz.Data.Repositories.Connections
{
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly IDatabase _database;
        private readonly ISettings _settings;


        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionRepository"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="settings">The settings.</param>
        public ConnectionRepository(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        /// <summary>
        /// Gets the connections for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{IGroupItem}.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<IGroupItem> GetConnectionsForUser(string username)
        {
            _database.ConnectionStringName = "sql";
            _database.CommandType = CommandType.StoredProcedure;
            var items = new List<IGroupItem>();

            var results = _database.List<ConnectionResult, object>("User_GetConnectionsByUsername", new{username}).ToList();

            string rootUrl = _settings.CloudUrl;

            foreach (var result in results)
            {
                result.Url = string.Format("{0}/{1}", rootUrl, result.Url);
                items.Add(result);
            }

            return items;
        }
    }
}