using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.Projections.Momentos;
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
            var success = View("Home");
            return Query<object, List<MomentoWithMedia>>(null, success);
        }

    }
}
