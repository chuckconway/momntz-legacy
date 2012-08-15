using System.Web.Mvc;
using Momntz.UI.Models.Login;

namespace Momntz.UI.Controllers
{
    public class SignupController : Controller
    {
        //
        // GET: /Signup/

        public ActionResult Index()
        {
            return View(new LoginView());
        }

    }
}
