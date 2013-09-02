using System;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Repositories.MomentoMedia.Parameters;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;
using NHibernate;

namespace Momntz.Data.Repositories.MomentoMedia
{
    public class MomentoMedia : IMomentoMedia
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoMedia"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        public MomentoMedia(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Finds the name of the momento by size and name.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="username">The username.</param>
        /// <returns>Momento.</returns>
        public Tile FindMomentoBySizeAndName(int size, string filename, string username)
        {
            using (var trans = _session.BeginTransaction())
            {
                var momento = _session.QueryOver<Schema.MomentoMedia>()
                    .Where(m => m.MediaType == MomentoMediaType.OriginalImage)
                    .And(m => m.Filename == filename)
                    .And(m => m.Size == size)
                    .Where(m => m.CreateDate > DateTime.UtcNow.AddHours(-1))

                    .JoinQueryOver(a => a.Momento)
                    .Where(e => e.User.Username == username)
                    .Select(f => f.Momento)
                    .List<Momento>();

                trans.Commit();

                if (momento.Count() == 1)
                {
                    return momento.Single().ConvertToTile(_settings);
                }

                return null;
            }
        }

        /// <summary>
        /// Finds the name of the momento from album by size and name.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Momento.</returns>
        public Tile FindMomentoFromAlbumBySizeAndName(FindMomentoFromAlbumBySizeAndNameInParameters args)
        {
            using (var trans = _session.BeginTransaction())
            {
                var momentos = _session.QueryOver<AlbumMomento>()
                    .Where(m => m.Album.Id == args.AlbumId)

                    .JoinQueryOver(a => a.Momento)
                    .Where(e => e.User.Username == args.Username)
                    .Select(f => f.Momento)
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
}