using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Momntz.Data.CommandHandlers;
using Momntz.Data.Commands.Albums;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.ProjectionHandlers.Albums;
using Momntz.Data.ProjectionHandlers.Api;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Api;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IProjectionHandler<AlbumNameSearchParameters, List<AlbumNameResult>> _getLandingPageAlbum;
        private readonly ICommandHandler<RemoveAlbumCommand> _removeHandler;
        private readonly ICommandHandler<AddAlbumCommand> _addAlbum;
        private readonly IProjectionHandler<AlbumTileScrollInParamters, List<Tile>> _getScrollTiles;
        private readonly IProjectionHandler<AutoScrollInParameters, List<IGroupItem>> _getScrollImages;
        private readonly ICommandHandler<NewAlbumCommand> _newAlbum;
        private readonly IProjectionHandler<FindAlbumByNameInParameters, List<IGroupItem>> _getNewlyAddedAlbum;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController" /> class.
        /// </summary>
        /// <param name="getLandingPageAlbum">The get landing page album.</param>
        /// <param name="removeHandler">The remove handler.</param>
        /// <param name="addAlbum">The add album.</param>
        /// <param name="getScrollTiles">The get scroll tiles.</param>
        /// <param name="getScrollImages">The get scroll images.</param>
        /// <param name="newAlbum">The new album.</param>
        public AlbumsController(IProjectionHandler<AlbumNameSearchParameters, List<AlbumNameResult>> getLandingPageAlbum, 
            ICommandHandler<RemoveAlbumCommand> removeHandler,
            ICommandHandler<AddAlbumCommand> addAlbum,
            IProjectionHandler<AlbumTileScrollInParamters, List<Tile>> getScrollTiles,
            IProjectionHandler<AutoScrollInParameters, List<IGroupItem>> getScrollImages,
            ICommandHandler<NewAlbumCommand> newAlbum,
            IProjectionHandler<FindAlbumByNameInParameters, List<IGroupItem>> getNewlyAddedAlbum)
        {

            _getLandingPageAlbum = getLandingPageAlbum;
            _removeHandler = removeHandler;
            _addAlbum = addAlbum;
            _getScrollTiles = getScrollTiles;
            _getScrollImages = getScrollImages;
            _newAlbum = newAlbum;
            _getNewlyAddedAlbum = getNewlyAddedAlbum;
        }

        /// <summary>
        /// Indexes the specified term.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Index(string name)
        {
            string username = GetUsername();
            var parameters = new AlbumNameSearchParameters() { Term = name, Username = username };

            var results = _getLandingPageAlbum.Execute(parameters);
            return  Json(results.Select(a=> new AutoComplete(a.Name)), JsonRequestBehavior.AllowGet);
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
            _newAlbum.Execute(new NewAlbumCommand {Name = name, Story = story, Username = username});

            var items = _getNewlyAddedAlbum.Execute(new FindAlbumByNameInParameters {Name = name, Username = username});
            return Json(items);
        }

        /// <summary>
        /// Removes the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="momentoId">The momento id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Remove(string tag, int momentoId)
        {
            string username = GetUsername();
            _removeHandler.Execute(new RemoveAlbumCommand(tag, username, momentoId));
            return Content(string.Empty);
        }

        /// <summary>
        /// Adds the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="momentoId">The momento id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Add(string tag, int momentoId)
        {
            string username = GetUsername();
            _addAlbum.Execute(new AddAlbumCommand(tag, username, momentoId));
            return Content(string.Empty);
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
            var items = _getScrollTiles.Execute(new AlbumTileScrollInParamters { MomentoId = momentoId, Username = username, AlbumId = albumId });
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
            var items = _getScrollImages.Execute(new AutoScrollInParameters { AlbumId = albumId, Username = username });

            return Json(items);
        }
    }
}
