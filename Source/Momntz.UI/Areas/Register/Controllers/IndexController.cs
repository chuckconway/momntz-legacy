using System.Web.Mvc;
using Momntz.UI.Areas.Register.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Register.Controllers
{
    public class IndexController : MomntzController
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
        public ActionResult Index(RegisterIndexModel model)
        {
            var result = Redirect("/");
            return Form(model, result);
        }

    }
}
