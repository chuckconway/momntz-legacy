using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.ProjectionHandlers.Momentos;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProjectionHandler<HomepageInParameters, List<Tile>> _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public HomeController(IProjectionHandler<HomepageInParameters, List<Tile>> processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
           var tiles = _processor.Execute(new HomepageInParameters());
           return View(tiles);
        }

    }
}
