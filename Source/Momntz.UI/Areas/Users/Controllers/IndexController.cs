using System.Web.Mvc;
using Momntz.UI.Areas.Users.Handlers.Index;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class IndexController : BaseController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            string username = RouteData.Values["username"].ToString();
            
            bool isAuthenticatedUsersHomepage = IsAuthenticatedUser(username);

            return Query<GetUserMomentsInParameters, UserView>(new GetUserMomentsInParameters(){Username = username, IsAuthenticatedUser = isAuthenticatedUsersHomepage}, View());
        }

    }
}
