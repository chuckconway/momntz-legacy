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
                var momento = album.Momentos.FirstOrDefault();

                //get random image for Album cover image.
                if (momento != null)
                {
                    var media = (momento.Media != null ? momento.Media.Single(s => s.MediaType == MomentoMediaType.MediumImage) : null);

                    if (media != null)
                    {
                        var item = new AlbumResult
                        {
                            Name = album.Name,
                            Username = album.Username,
                            CreateDate = album.CreateDate,
                            Url = string.Format("{0}/{1}", rootUrl, media.Url)
                        };

                        results.Add(item);
                    }
                }
                else // default album without image
                {
                    var item = new AlbumResult
                    {
                        Name = album.Name,
                        Username = album.Username,
                        CreateDate = album.CreateDate,
                        Url = "/content/images/defaultalbum.png"
                        //Url = string.Format("{0}/{1}", rootUrl, media.Url)
                    };

                    results.Add(item);
                }

            }


            return results;

                //return (from album in items 
                //    let momento = album.Momentos.FirstOrDefault() 
                //    let media = (momento != null ? momento.Media.Single(s => s.MediaType == MomentoMediaType.MediumImage)  : null) 
                //    where momento != null
                //    select new AlbumResult {Name = album.Name, Username = album.Username, CreateDate = album.CreateDate, Url = string.Format("{0}/{1}", rootUrl, media.Url)}).Cast<IGroupItem>()
                //    .ToList();
        }
    }
}
