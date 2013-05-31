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
                return (from album in items 
                    let momento = album.Momentos.FirstOrDefault() 
                    let media = momento.Media.Single(s => s.MomentoMediaType == MomentoMediaType.MediumImage) 
                    select new AlbumResult {Name = album.Name, Username = album.Username, CreateDate = album.CreateDate, Url = string.Format("{0}/{1}", rootUrl, media.Url)}).Cast<IGroupItem>()
                    .ToList();
        }
    }
}
