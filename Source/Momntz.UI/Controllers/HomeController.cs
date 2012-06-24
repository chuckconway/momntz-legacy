using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.Projections.Momentos;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            var success = View();
            return Query<object, IList<MomentoWithMedia>>(null, success);
        }

    }
}
