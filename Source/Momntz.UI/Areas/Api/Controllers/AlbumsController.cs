using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Momntz.Data.Commands.Albums;
using Momntz.Data.ProjectionHandlers.Api;
using Momntz.Data.Projections.Api;
using Momntz.Infrastructure;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IProjectionProcessor _processor;
        private readonly ICommandProcessor _command;

        public AlbumsController(IProjectionProcessor processor, ICommandProcessor command)
        {
            _processor = processor;
            _command = command;
        }

        public ActionResult Index(string term)
        {
            string username = GetUsername();
            var parameters = new AlbumNameSearchParameters() {Term = term, Username = username};

            var results = _processor.Process<AlbumNameSearchParameters, List<AlbumNameResult>>(parameters);
            return Json(results.Select(a=> new AutoComplete(a.Name)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Remove(string tag, int momentoId)
        {
            string username = GetUsername();
            _command.Process(new RemoveAlbumCommand(tag, username, momentoId));
            return Content(string.Empty);
        }

        public ActionResult Add(string tag, int momentoId)
        {
            tag = HttpUtility.HtmlEncode(tag);

            string username = GetUsername();
            _command.Process(new AddAlbumCommand(tag, username, momentoId));
            return Content(string.Empty);
        }

    }
}
