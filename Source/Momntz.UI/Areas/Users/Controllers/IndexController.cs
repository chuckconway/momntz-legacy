using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class IndexController : BaseController
    {
        public ActionResult Index()
        {
            string username = RouteData.Values["username"].ToString();
            return Query<string, List<MomentoWithMedia>>(username, View());
        }

    }
}
