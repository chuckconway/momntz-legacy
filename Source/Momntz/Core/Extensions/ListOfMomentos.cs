using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Schema;
using Momntz.Infrastructure.Configuration;


namespace Momntz.Core.Extensions
{
    public static class ListOfMomentos
    {
        /// <summary>
        /// Converts to tiles.
        /// </summary>
        /// <param name="momentos">The momentos.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>List{Tile}.</returns>
        public static List<Tile> ConvertToTiles(this IList<Momento> momentos, ISettings settings)
        {
            return momentos
                .Select(item => ConvertToTile(item, settings))
                .Where(tile => tile != null).ToList();
        }

        /// <summary>
        /// Converts the automatic tile.
        /// </summary>
        /// <param name="c">The asynchronous.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Tile.</returns>
        public static Tile ConvertToTile(this Momento c, ISettings settings)
        {
            if (c.Media != null && c.Media.Any())
            {
                var url = string.Format("{0}/{1}", settings.CloudUrl,
                    c.Media.Single(i => i.MediaType == MomentoMediaType.MediumImage).Url);

                var tile = new Tile
                {
                    Id = c.Id,
                    ImageUrl = url,
                    Story = c.Story,
                    Title = c.Title,
                    Username = c.User.Username,
                    FullName = c.User.FullName,
                    CreateDate = c.CreateDate
                };

                return tile;
            }

            return null;
        }
    }
}
