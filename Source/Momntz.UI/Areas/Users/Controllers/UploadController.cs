using System.Web;
using System.Web.Mvc;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;


namespace Momntz.UI.Areas.Users.Controllers
{
    public class UploadController : BaseController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            string landingPageUser = CurrentLandingPageUsername();
            bool isSignedIn = IsAuthenticatedUser(landingPageUser);

            return View(new UploadView(){IsAuthenticatedUser = isSignedIn, Username = landingPageUser});
        }

        /// <summary>
        /// Indexes the specified filedata.
        /// </summary>
        /// <param name="filedata">The filedata.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase filedata)
        {
           
            return Content("Error");
        }

    }
}
