using System.Collections.Generic;
using System.Linq;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Albums;
using Momntz.Data.Schema;


namespace Momntz.Core.Extensions
{
    public static class ListOfAlbums
    {
        /// <summary>
        /// Converts to group item.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="rootUrl">The root URL.</param>
        /// <returns>List{IGroupItem}.</returns>
        public static List<IGroupItem> ConvertToGroupItems(this IList<Album> items, string rootUrl)
        {
            var results = new List<IGroupItem>();

            foreach (var album in items)
            {
                GetMedia(rootUrl, album, results);
            }

            return results;

                //return (from album in items 
                //    let momento = album.Momentos.FirstOrDefault() 
                //    let media = (momento != null ? momento.Media.Single(s => s.MediaType == MomentoMediaType.MediumImage)  : null) 
                //    where momento != null
                //    select new AlbumResult {Name = album.Name, Username = album.Username, CreateDate = album.CreateDate, Url = string.Format("{0}/{1}", rootUrl, media.Url)}).Cast<IGroupItem>()
                //    .ToList();
        }

        /// <summary>
        /// Gets the media.
        /// </summary>
        /// <param name="rootUrl">The root URL.</param>
        /// <param name="album">The album.</param>
        /// <param name="results">The results.</param>
        private static void GetMedia(string rootUrl, Album album, List<IGroupItem> results)
        {
            var momento = album.Momentos.FirstOrDefault();

            //get random image for Album cover image.
            if (momento != null)
            {
                var media = (momento.Media != null
                    ? momento.Media.Single(s => s.MediaType == MomentoMediaType.MediumImage)
                    : null);

                if (media != null)
                {
                    string url = string.Format("{0}/{1}", rootUrl, media.Url);
                    var item = PopulateAlbumResult(album, url);

                    results.Add(item);
                }
            }
            else // default album without image
            {
                const string url = "/content/images/defaultalbum.png";
                var item = PopulateAlbumResult(album, url);

                results.Add(item);
            }
        }

        /// <summary>
        /// Populates the album result.
        /// </summary>
        /// <param name="album">The album.</param>
        /// <param name="url">The URL.</param>
        /// <returns>AlbumResult.</returns>
        private static AlbumResult PopulateAlbumResult(Album album, string url)
        {
            var item = new AlbumResult
            {
                Id = album.Id,
                Name = album.Name,
                Username = album.Username,
                CreateDate = album.CreateDate,
                Url = url
            };
            return item;
        }
    }
}
