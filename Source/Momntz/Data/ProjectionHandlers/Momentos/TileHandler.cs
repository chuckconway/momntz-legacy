using System;
using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Momentos;
using Momntz.Model;
using Momntz.Model.Configuration;
using NHibernate;

namespace Momntz.Data.ProjectionHandlers.Momentos
{
    /// <summary>
    /// Class TileHandler
    /// </summary>
    public class TileHandler : IProjectionHandler<DateTime, List<Tile>>
    {
        private readonly ISession _session;
        private readonly ISettings _settings;

        public TileHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }

        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> Execute(DateTime args)
        {
            using (var trans = _session.BeginTransaction())
            {
               var items = _session.QueryOver<Momento>()
                        .Where(m => m.CreateDate < args)
                        .Take(20)
                        .List();

                trans.Commit();

                return ConvertMomentosToTiles(items);
            }
        }

        /// <summary>
        /// Converts the momentos to tiles.
        /// </summary>
        /// <param name="momentos">The momentos.</param>
        /// <returns>List{Tile}.</returns>
        private List<Tile> ConvertMomentosToTiles(IEnumerable<Momento> momentos)
        {
            var tiles = new List<Tile>();

            foreach (var momento in momentos)
            {
               var url = string.Format("{0}/{1}", _settings.CloudUrl, momento.Media.Single(i => i.MediaType == MediaType.MediumImage).Url);

                var tile = new Tile();
                tile.Id = momento.Id;
                tile.ImageUrl = url;
                tile.Story = momento.Story;
                tile.Title = momento.Title;
                tile.Username = momento.Username;

                tiles.Add(tile);
            }

            

            return tiles;
        }
    }
}
