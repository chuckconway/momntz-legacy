using System.IO;
using System.Web;
using System.Web.Mvc;
using Momntz.Infrastructure;
using Momntz.UI.Core;
using Momntz.UI.Core.ActionFilters;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class ImportController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportController" /> class.
        /// </summary>
        /// <param name="commandProcessor">The command processor.</param>
        public ImportController(ICommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        private readonly ICommandProcessor _commandProcessor;

        /// <summary>
        /// Adds the momento.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ApiAuthorization]
        public ActionResult AddMomento(string filename, string username)
        {
            byte[] bytes = null;

            var uploader = new MomentoUploader(_commandProcessor);
            var id = uploader.Add(filename, username, bytes);

            return Json(new {Id = id});
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        [ApiAuthorization]
        public ActionResult GetUser(string username)
        {
            return Json(new {username});
        }

        private static byte[] GetBytes(HttpPostedFile file)
        {
            var memoryStream = new MemoryStream();
            file.InputStream.CopyTo(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            return bytes;
        }

    }
}
