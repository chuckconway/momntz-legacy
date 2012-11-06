using System.IO;
using System.Web;
using Momntz.Infrastructure;
using Momntz.UI.Core.Controllers;
using StructureMap;


namespace Momntz.UI.Core.RouteHandler
{
    public class UploadHttpHandler : IHttpHandler
    {
        private readonly ICommandProcessor _commandProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadHttpHandler" /> class.
        /// </summary>
        public UploadHttpHandler()
        {
            _commandProcessor = ObjectFactory.GetInstance<ICommandProcessor>();
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            //IStorage storage = new AzureStorage();
            //storage.AddFile("img", file.FileName, file.ContentType, file.InputStream);

            //Image formats
            //jpg, jpeg, png, gif, tiff

            //Documents Formats
            //PDF, doc, docx, text
            var file = context.Request.Files["filedata"];

            var bytes = GetBytes(file);
            var username = BaseController.AuthenticatedUsername(); 

            MomentoUploader uploader = new MomentoUploader(_commandProcessor);
            uploader.Add(file.FileName, username, bytes);
           
            context.Response.Write("1");
        }

        private static byte[] GetBytes(HttpPostedFile file)
        {
            var memoryStream = new MemoryStream();
            file.InputStream.CopyTo(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            return bytes;
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}