using System.Web.Mvc;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Controllers
{
    public class SignoutController : BaseController
    {
        public ActionResult Index()
        {
            string username = Username;
            return Redirect(string.Format("/{0}", username));
        }

    }
}
