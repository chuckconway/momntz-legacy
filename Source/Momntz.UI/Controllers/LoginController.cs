using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Users;
using Momntz.Infrastructure.Logging;
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

        /// <summary>
        /// Indexes the specified username and password.
        /// </summary>
        /// <param name="usernameAndPassword">The username and password.</param>
        /// <returns>ActionResult.</returns>
        [LogToFile]
        [HttpPost]
        public ActionResult Index(UsernameAndPassword usernameAndPassword)
        {
            var success = Redirect(string.Format("/{0}", usernameAndPassword.Username));
            return Form(usernameAndPassword, success);
        }
    }
}
