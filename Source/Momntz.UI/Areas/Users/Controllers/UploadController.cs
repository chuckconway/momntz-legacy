using System.Web;
using System.Web.Mvc;
using Momntz.UI.Core.Controllers;


namespace Momntz.UI.Areas.Users.Controllers
{
    public class UploadController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase filedata)
        {
            //IStorage storage = new AzureStorage();
            //storage.AddFile("img", filedata.FileName, filedata.ContentType, filedata.InputStream);
            
            return Content("Error");
        }

        //public ActionResult Test()
        //{
        //    CreateMediaCommandTests tests = new CreateMediaCommandTests();
        //    tests.CreateMedia_InsertNewMedia_IsCorrectlyInsertedIntoTheQueueDatabase();

        //    return Content("");
        //}

    }
}
