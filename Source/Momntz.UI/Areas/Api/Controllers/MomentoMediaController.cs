using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Repositories.MomentoMedia;
using Momntz.Data.Repositories.MomentoMedia.Parameters;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class MomentoMediaController : BaseController
    {
        private readonly IMomentoMediaRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MomentoMediaController" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public MomentoMediaController(IMomentoMediaRepository repository)
        {
            _repository = repository;
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
            var tile = _repository.FindMomentoBySizeAndName(size, filename, username);

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
            var tile = _repository.FindMomentoFromAlbumBySizeAndName(new FindMomentoFromAlbumBySizeAndNameInParameters
                        {
                            Filename = filename,
                            Size = size,
                            Username = username,
                            AlbumId = albumId
                        });

            return Json(new List<Tile>{tile});
        }

    }
}
