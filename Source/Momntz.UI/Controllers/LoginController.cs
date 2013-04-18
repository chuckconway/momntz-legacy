using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Users;
using Momntz.UI.Core.Controllers;
using Momntz.UI.Models.Login;

namespace Momntz.UI.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Index()
        {
            return View(new LoginView());
        }

        [HttpPost]
        public ActionResult Index(UsernameAndPassword usernameAndPassword)
        {
            var success = Redirect(string.Format("/{0}", usernameAndPassword.Username));
            return Form(usernameAndPassword, success);
        }
    }
}
