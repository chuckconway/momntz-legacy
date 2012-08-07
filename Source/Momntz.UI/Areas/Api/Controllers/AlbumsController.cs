using System.Collections.Generic;
using System.Web.Mvc;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class AlbumsController : Controller
    {
        public ActionResult Index(string query)
        {
            List<string> results = new List<string> {query};

            return Json(results, JsonRequestBehavior.AllowGet);
        }

    }
}
