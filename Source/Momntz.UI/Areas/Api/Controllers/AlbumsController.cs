using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.Commands.Albums;
using Momntz.Data.ProjectionHandlers.Albums;
using Momntz.Data.ProjectionHandlers.Api;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Api;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IProjectionProcessor _processor;
        private readonly ICommandProcessor _command;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="command">The command.</param>
        public AlbumsController(IProjectionProcessor processor, ICommandProcessor command)
        {
            _processor = processor;
            _command = command;
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

            var results = _processor.Process<AlbumNameSearchParameters, List<AlbumNameResult>>(parameters);
            return Json(results.Select(a=> new AutoComplete(a.Name)), JsonRequestBehavior.AllowGet);
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
            _command.Process(new RemoveAlbumCommand(tag, username, momentoId));
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
            _command.Process(new AddAlbumCommand(tag, username, momentoId));
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
            var items = _processor.Process<AlbumTileScrollInParamters, List<Tile>>(new AlbumTileScrollInParamters { CreateDate = parsed, Username = username, Name = name});

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
            var items = _processor.Process<AutoScrollInParameters, List<IGroupItem>>(new AutoScrollInParameters{CreateDate = parsed, Username = username});

            return Json(items);
        }

    }
}
