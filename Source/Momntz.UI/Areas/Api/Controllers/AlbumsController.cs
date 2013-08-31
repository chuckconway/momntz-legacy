using System.Web.Mvc;
using Momntz.Data.CommandHandlers.Albums;
using Momntz.Data.CommandHandlers.Albums.Parameters;
using Momntz.Data.Commands.Albums;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public AlbumsController(IAlbumRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// News the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="story">The story.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult New(string name, string story)
        {
            string username = GetUsername();

            _repository.New(new NewAlbumParameters { Name = name, Story = story, Username = username });
            var items = _repository.FindNewlyAddedByName(new FindAlbumByNameInParameters {Name = name, Username = username});

            return Json(items);
        }

        /// <summary>
        /// Tiles the scroll.
        /// </summary>
        /// <param name="momentoId">The momento unique identifier.</param>
        /// <param name="albumId">The album unique identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult TileScroll(int momentoId, int albumId, string username)
        {
           var items = _repository.GetNextMomentos(new AlbumTileScrollInParamters { MomentoId = momentoId, Username = username, AlbumId = albumId });
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
            var items = _repository.GetNextAlbums(new AutoScrollInParameters {AlbumId = albumId, Username = username});
            return Json(items);
        }
    }
}
