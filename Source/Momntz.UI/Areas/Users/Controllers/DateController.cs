using System.Web.Mvc;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class DateController : Controller
    {
        //
        // GET: /Users/Date/

        public ActionResult Index(int? year, int? month, int? day)
        {
            return Content(string.Empty);
        }

    }
}
