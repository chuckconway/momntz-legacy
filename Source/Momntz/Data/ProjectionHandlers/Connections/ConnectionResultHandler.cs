﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using Hypersonic;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Connections;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Connections
{
    public class ConnectionResultHandler : IProjectionHandler<string, List<IGroupItem>>
    {
        private readonly IDatabase _database;
        private readonly ISettings _settings;


        public ConnectionResultHandler(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        public List<IGroupItem> Execute(string args)
        {
            _database.ConnectionStringName = "sql";
            _database.CommandType = CommandType.StoredProcedure;
            List<IGroupItem> items = new List<IGroupItem>();
            
            var results = _database.List<ConnectionResult, object>("User_GetConnectionsByUsername", new { Username = args }).ToList();

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