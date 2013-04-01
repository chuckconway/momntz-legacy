﻿using System.Collections.Generic;
using Hypersonic;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using ISession = NHibernate.ISession;

namespace Momntz.Data.ProjectionHandlers.Albums
{
    public class AlbumMomentosHandler : IProjectionHandler<AlbumMomentosParameters, List<Tile>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumMomentosHandler"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public AlbumMomentosHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> Execute(AlbumMomentosParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                Tag tag = null;
                var items = _session.QueryOver<TagMomento>()
                                    .JoinQueryOver(t=>t.Tag, ()=>tag)
                                    .Where(() => tag.Kind == (int)KindOfTag.Album)
                                    .And(() => tag.Username == args.Username)
                                    .And(() => tag.Name == args.Name)
                                    .SelectList(list=>list.Select(t=>t.Momento))
                                    .Take(40)
                                    .List<Momento>();

                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
        }
    }

    public class AlbumMomentosParameters
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
}
