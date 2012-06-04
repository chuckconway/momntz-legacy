using System.Web;
using Momntz.Worker.Core;
using Momntz.Worker.Core.Implementations.Storage;

namespace Momntz.UI.Core.RouteHandler
{
    public class UploadHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //Image formats
            // jpg, jpeg, png, gif, tiff

            //Documents Formats
            //PDF, doc, docx, text

            var file = context.Request.Files["filedata"];
            
            IStorage storage = new AzureStorage();
            storage.AddFile("img", file.FileName, file.ContentType, file.InputStream);

            context.Response.Write("1");
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}