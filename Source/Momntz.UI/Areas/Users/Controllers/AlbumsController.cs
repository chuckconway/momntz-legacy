using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Albums;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class AlbumsController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        public AlbumsController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        public ActionResult Name(string name)
        {
            var username = CurrentLandingPageUsername();
            var results = _processor.Process<AlbumMomentosParameters, List<MomentoWithMedia>>(new AlbumMomentosParameters(){Name = name, Username = username});

            return View(results);
        }

        public ActionResult Index()
        {
            string username = CurrentLandingPageUsername();

            var items = _processor.Process<AlbumResultsParameters, List<IGroupItem>>(new AlbumResultsParameters() {Username = username});
            return View(items);
        }

    }
}
