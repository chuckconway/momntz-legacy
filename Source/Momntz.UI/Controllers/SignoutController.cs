using System.Web.Mvc;
using System.Web.Security;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Controllers
{
    public class SignoutController : BaseController
    {
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();

            string username = Username;
            return Redirect(string.Format("/{0}", username));
        }

    }
}
