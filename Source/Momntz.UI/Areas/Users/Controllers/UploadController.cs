using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Momntz.Worker.Core;

namespace Momntz.UI.Areas.Users.Controllers
{
    public class UploadController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase filedata)
        {
            IStorage storage = new AzureStorage();
            storage.AddFile("img", filedata.FileName, filedata.ContentType, filedata.InputStream);
            
            return Content("Error");
        }

    }
}
