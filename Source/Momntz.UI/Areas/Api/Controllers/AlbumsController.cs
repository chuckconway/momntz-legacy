using System;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="getLandingPageAlbum"></param>
        /// <param name="command">The command.</param>
        public AlbumsController(IProjectionHandler<AlbumNameSearchParameters, List<AlbumNameResult>> getLandingPageAlbum, 
            ICommandHandler<RemoveAlbumCommand> removeHandler,
            ICommandHandler<AddAlbumCommand> addAlbum,
            IProjectionHandler<AlbumTileScrollInParamters, List<Tile>> getScrollTiles,
            IProjectionHandler<AutoScrollInParameters, List<IGroupItem>> getScrollImages )
        {

            _getLandingPageAlbum = getLandingPageAlbum;
            _removeHandler = removeHandler;
            _addAlbum = addAlbum;
            _getScrollTiles = getScrollTiles;
            _getScrollImages = getScrollImages;
        }

        /// <summary>
        /// Indexes the specified term.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Index(string name)
        {
            string username = GetUsername();
            var parameters = new AlbumNameSearchParameters() { Term = name, Username = username };

            var results = _getLandingPageAlbum.Execute(parameters);
            return  Json(results.Select(a=> new AutoComplete(a.Name)), JsonRequestBehavior.AllowGet);
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
        /// <param name="oldest">The oldest.</param>
        /// <param name="name">The name.</param>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult TileScroll(string oldest, string name, string username)
        {
            DateTime parsed = DateTime.Parse(oldest);
            var items = _getScrollTiles.Execute(new AlbumTileScrollInParamters { CreateDate = parsed, Username = username, Name = name });

            return Json(items);
        }

        /// <summary>
        /// Albums the scroll.
        /// </summary>
        /// <param name="oldest">The oldest.</param>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult AlbumScroll(string oldest, string username)
        {
            DateTime parsed = DateTime.Parse(oldest);
            var items = _getScrollImages.Execute(new AutoScrollInParameters { CreateDate = parsed, Username = username });

            return Json(items);
        }

    }
}
