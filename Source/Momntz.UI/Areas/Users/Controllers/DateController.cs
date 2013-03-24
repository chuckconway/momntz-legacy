using System.Web.Mvc;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class DateController : Controller
    {
        public ActionResult Index(int? year, int? month, int? day)
        {
            return View();
        }

    }
}
