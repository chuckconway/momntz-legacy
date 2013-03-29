using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hypersonic;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Albums;
using Momntz.Model.Configuration;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AutoScrollHandler : BaseGroupItem, IProjectionHandler<AutoScrollInParameters, List<IGroupItem>>
    {
        private readonly IDatabase _database;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoScrollHandler" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="settings">The settings.</param>
        public AutoScrollHandler(IDatabase database, ISettings settings)
        {
            _database = database;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{IGroupItem}.</returns>
        public List<IGroupItem> Execute(AutoScrollInParameters args)
        {
            _database.ConnectionStringName = "sql";
            var results = _database.List<AlbumResult, object>("TagAlbum_GetAlbumByUsernameScroll", args).ToList();
            return GetItems(_settings, results);
        }
    }

    public class AutoScrollInParameters
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime CreateDate { get; set; }
    }
}
