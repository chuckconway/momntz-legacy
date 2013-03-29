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
    public abstract class TileHandler<T> : IProjectionHandler<T, List<Tile>>
    {
        protected readonly ISession _session;
        private readonly ISettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="TileHandler{T}"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="settings">The settings.</param>
        protected TileHandler(ISession session, ISettings settings)
        {
            _session = session;
            _settings = settings;
        }
        
        /// <summary>
        /// Executes the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>List{Tile}.</returns>
        public abstract List<Tile> Execute(T args);
        
        /// <summary>
        /// Converts the momentos to tiles.
        /// </summary>
        /// <param name="momentos">The momentos.</param>
        /// <returns>List{Tile}.</returns>
        protected List<Tile> ConvertMomentosToTiles(IEnumerable<Momento> momentos)
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
                tile.CreateDate = momento.CreateDate;

                tiles.Add(tile);
            }

            

            return tiles;
        }
    }
}
