using System.Web.Mvc;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure.Processors;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class MediaController : Controller
    {
        private readonly IProjectionProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public MediaController(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Indexes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Index(int id)
        {
           var momento = _processor.Process<int, MomentoWithMedia>(id);
           return View(momento);
        }

    }
}
