using System;
using System.Collections.Generic;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;

using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AlbumNameScrollHandler : IProjectionHandler<AlbumTileScrollInParamters, List<Tile>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumNameScrollHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public AlbumNameScrollHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> Execute(AlbumTileScrollInParamters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.CreateQueryProcedure<object>("Album_GetNext40Momentos", args)
                    .List<object>();

                var ids = items.Cast<IDictionary<string, string>>().Select(i => (object)i["Id"]).ToArray();

                Momento m = null;
               var momentos = _session.QueryOver<Momento>()
                    .Where(Restrictions.In("Id", ids))
                    .List()
                    .ToList()
                    .ConvertToTiles(_settings);

                trans.Commit();
                return momentos;
            }
        }
    }

    public class AlbumTileScrollInParamters
    {
        /// <summary>
        /// Gets or sets the album unique identifier.
        /// </summary>
        /// <value>The album unique identifier.</value>
        public int AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public int  MomentoId { get; set; }
    }
}
