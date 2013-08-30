using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.ProjectionHandlers.MomentoMedia;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class MomentoMediaController : BaseController
    {
        private readonly IProjectionHandler<FindMomentoFromAlbumBySizeAndNameInParameters, Tile> _getAlbumMedia;
        private readonly IProjectionHandler<FindMomentoBySizeAndNameInParameters, Tile> _getMedia;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoMediaController" /> class.
        /// </summary>
        /// <param name="getAlbumMedia">The get album media.</param>
        public MomentoMediaController(IProjectionHandler<FindMomentoFromAlbumBySizeAndNameInParameters, Tile> getAlbumMedia,
            IProjectionHandler<FindMomentoBySizeAndNameInParameters, Tile> getMedia)
        {
            _getAlbumMedia = getAlbumMedia;
            _getMedia = getMedia;
        }

        /// <summary>
        /// Gets the newly added photo.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="size">The size.</param>
        /// <param name="albumId">The album unique identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult GetNewlyAddedPhoto(string filename, int size)
        {
            string username = GetUsername();
            var tile = _getMedia.Execute(new FindMomentoBySizeAndNameInParameters { Filename = filename, Size = size, Username = username });

            return Json(new List<Tile> { tile });
        }

        /// <summary>
        /// Gets the newly added photo.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="size">The size.</param>
        /// <param name="albumId">The album unique identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult GetNewlyAddedAlbumPhoto(string filename, int size, int albumId)
        {
            string username = GetUsername();
            var tile = _getAlbumMedia.Execute(new FindMomentoFromAlbumBySizeAndNameInParameters { Filename = filename, Size = size, Username = username, AlbumId = albumId });

            return Json(new List<Tile>{tile});
        }

    }
}
