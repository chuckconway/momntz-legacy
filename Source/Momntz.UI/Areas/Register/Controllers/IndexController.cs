using System.Web.Mvc;
using Momntz.UI.Areas.Register.Models;

namespace Momntz.UI.Areas.Register.Controllers
{
    public class IndexController : Controller
    {
        /// <summary> Gets the index. </summary>
        /// <returns> . </returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary> Indexes. </summary>
        /// <param name="model"> The model. </param>
        /// <returns> . </returns>
        [HttpPost]
        public ActionResult Index(RegisterIndexModel model)
        {
            return View();
        }

    }
}
