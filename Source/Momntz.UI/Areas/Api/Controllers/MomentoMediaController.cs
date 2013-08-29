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
        private readonly IProjectionHandler<FindMomentoSizeAndNameInParameters, Tile> _getmedia;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoMediaController"/> class.
        /// </summary>
        /// <param name="getmedia">The getmedia.</param>
        public MomentoMediaController(IProjectionHandler<FindMomentoSizeAndNameInParameters, Tile> getmedia)
        {
            _getmedia = getmedia;
        }

        /// <summary>
        /// Gets the newly added photo.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="size">The size.</param>
        /// <param name="albumId">The album unique identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult GetNewlyAddedPhoto(string filename, int size, int albumId)
        {
            string username = GetUsername();
            var tile = _getmedia.Execute(new FindMomentoSizeAndNameInParameters{Filename = filename, Size = size, Username = username, AlbumId = albumId});

            return Json(new List<Tile>{tile});
        }

    }
}
