using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProjectionProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public HomeController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
           var tiles = _processor.Process<HomepageInParameters, List<Tile>>(new HomepageInParameters());
           return View(tiles);
            //return Query<object, List<MomentoWithMedia>>(null, success);
        }

    }
}
