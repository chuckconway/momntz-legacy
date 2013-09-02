using System.Web.Mvc;
using Momntz.Data.Repositories.Albums;
using Momntz.Data.Repositories.Albums.Parameters;
using Momntz.Data.Repositories.Momentos;
using Momntz.Data.Repositories.Momentos.Parameters;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class ScrollController : Controller
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMomentoRepository _momentoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollController" /> class.
        /// </summary>
        /// <param name="albumRepository">The album repository.</param>
        public ScrollController(IAlbumRepository albumRepository, IMomentoRepository momentoRepository)
        {
            _albumRepository = albumRepository;
            _momentoRepository = momentoRepository;
        }

        /// <summary>
        /// Tiles the scroll.
        /// </summary>
        /// <param name="momentoId">The momento unique identifier.</param>
        /// <param name="albumId">The album unique identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult AlbumTileScroll(int momentoId, int albumId, string username)
        {
            var items = _albumRepository.GetNextMomentos(new AlbumTileScrollInParamters { MomentoId = momentoId, Username = username, AlbumId = albumId });
            return Json(items);
        }


        /// <summary>
        /// Albums the scroll.
        /// </summary>
        /// <param name="albumId">The album unique identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult AlbumScroll(int albumId, string username)
        {
            var items = _albumRepository.GetNextAlbums(new AutoScrollInParameters { AlbumId = albumId, Username = username });
            return Json(items);
        }

        /// <summary>
        /// Scrolls the specified oldest.
        /// </summary>
        /// <param name="momentoId">The momento unique identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult UserScroll(int momentoId, string username)
        {
            var items = _momentoRepository.InfiniteScroll(new UserInfiniteScrollInParameters { MomentoId = momentoId, Username = username });
            return Json(items);
        }

    }
}
