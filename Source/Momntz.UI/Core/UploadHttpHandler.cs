using System.Web;
using Momntz.Worker.Core;

namespace Momntz.UI.Core
{
    public class UploadHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
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