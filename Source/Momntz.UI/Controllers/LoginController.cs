using System.Web.Mvc;
using System.Web.Security;
using Momntz.Data.ProjectionHandlers.Users;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure;
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
        public ActionResult Index(string username, string password)
        {
            var success = Redirect(string.Format("/{0}", username));
            return Form(new UsernameAndPassword(username, password), success);
        }
    }
}
