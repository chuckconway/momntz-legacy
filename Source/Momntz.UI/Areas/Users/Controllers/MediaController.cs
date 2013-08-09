using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.Projections.Momentos;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class MediaController : Controller
    {
        private readonly IProjectionHandler<int, Tile> _getTilebyId;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaController" /> class.
        /// </summary>
        /// <param name="getTilebyId">The get tileby id.</param>
        public MediaController(IProjectionHandler<int, Tile> getTilebyId )
        {
            _getTilebyId = getTilebyId;
        }

        /// <summary>
        /// Indexes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Index(int id)
        {
            var tile = _getTilebyId.Execute(id);
           return View(tile);
        }

    }
}
