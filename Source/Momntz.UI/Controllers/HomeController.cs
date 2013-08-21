using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Users;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Indexes the specified username and password.
        /// </summary>
        /// <param name="usernameAndPassword">The username and password.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Index(UsernameAndPassword usernameAndPassword)
        {
            var success = Redirect(string.Format("/{0}", usernameAndPassword.Username));
            return Form(usernameAndPassword, success);
        }

    }
}
