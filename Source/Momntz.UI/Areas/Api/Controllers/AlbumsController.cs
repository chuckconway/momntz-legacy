using System.Collections.Generic;
using System.Web.Mvc;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class AlbumsController : Controller
    {
        public ActionResult Index(string term)
        {
            List<string> results = new List<string> {term, "might", "man"};

            return Json(results, JsonRequestBehavior.AllowGet);
        }

    }
}
