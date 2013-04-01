using System;
using System.Collections.Generic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Api;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using NHibernate;
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
                Tag tag = null;
                var items = _session.QueryOver<TagMomento>()
                                    .JoinQueryOver(t => t.Tag, () => tag)
                                    .Where(() => tag.Kind == (int)KindOfTag.Album)
                                    .And(() => tag.Username == args.Username)
                                    .And(() => tag.Name == args.Name)
                                    .SelectList(list => list.Select(t => t.Momento))
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
