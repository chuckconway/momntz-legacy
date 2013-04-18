using System.Web.Mvc;
using Momntz.UI.Areas.Join.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Join.Controllers
{
    public class IndexController : BaseController
    {
        /// <summary> Gets the index. </summary>
        /// <returns> . </returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary> Indexes. </summary>
        /// <param name="model"> The model. </param>
        /// <returns> . </returns>
        [HttpPost]
        public ActionResult Index(JoinIndexModel model)
        {
            var result = Redirect("/");
            return Form(model, result);
        }

    }
}
