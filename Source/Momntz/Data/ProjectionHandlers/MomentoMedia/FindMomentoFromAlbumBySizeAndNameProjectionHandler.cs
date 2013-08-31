﻿using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.MomentoMedia
{
    public class FindMomentoFromAlbumBySizeAndNameProjectionHandler : IProjectionHandler<FindMomentoFromAlbumBySizeAndNameInParameters, Tile>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindMomentoBySizeAndNameProjectionHandler" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public FindMomentoFromAlbumBySizeAndNameProjectionHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Momento.</returns>
        public Tile Execute(FindMomentoFromAlbumBySizeAndNameInParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var momentos = _session.QueryOver<AlbumMomento>()
                    .Where(m => m.Album.Id == args.AlbumId)

                    .JoinQueryOver(a => a.Momento)
                    .Where(e => e.User.Username == args.Username)
                    .Select(f=>f.Momento)
                    .List<Momento>();

                trans.Commit();

                //At some point this needs to be moved to the database.
                var momento = (from m in momentos
                    from media in m.Media
                    where media.MediaType == MomentoMediaType.OriginalImage
                          && media.Size == args.Size
                          && media.Filename == args.Filename
                    select m).ToList();

                if (momento.Count() == 1)
                {
                    return momento.Single().ConvertToTile(_settings);
                }

                return null;
            }
        }
    }

    public class FindMomentoFromAlbumBySizeAndNameInParameters
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the album unique identifier.
        /// </summary>
        /// <value>The album unique identifier.</value>
        public int AlbumId { get; set; }
    }
}