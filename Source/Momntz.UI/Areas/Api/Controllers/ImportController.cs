using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Momntz.Data.Projections.Import;
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
        /// <param name="processor">The processor.</param>
        public ImportController(ICommandProcessor commandProcessor, IProjectionProcessor processor)
        {
            _commandProcessor = commandProcessor;
            _processor = processor;
        }

        private readonly ICommandProcessor _commandProcessor;
        private readonly IProjectionProcessor _processor;

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
            Guid apiKey = Guid.Parse(this.ControllerContext.RequestContext.HttpContext.Request.QueryString["key"]);
           string un = _processor.Process<GetApiUserProjection, string>(new GetApiUserProjection() { Username = username, ApiKey = apiKey });
            return Json(new {username = un}, JsonRequestBehavior.AllowGet);
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
