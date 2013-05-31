using System;
using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;

using NHibernate;

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
                var items = _session.QueryOver<Momento>()
                                    .Where((m) => m.User.Username == args.Username)
                                    .And(m=>m.CreateDate < args.CreateDate)
                                    .JoinQueryOver<Album>(m => m.Albums)
                                    .Where(a => a.Name == args.Name)
                                    .Take(40)
                                    .List<Momento>();

                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
        }
    }

    public class AlbumTileScrollInParamters
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

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
