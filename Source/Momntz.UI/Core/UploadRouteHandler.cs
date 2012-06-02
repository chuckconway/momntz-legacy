using System.Web;
using System.Web.Routing;

namespace Momntz.UI.Core
{
    public class UploadRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new UploadHttpHandler();
        }
    }
}