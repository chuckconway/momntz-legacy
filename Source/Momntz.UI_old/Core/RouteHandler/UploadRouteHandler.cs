using System.Web;
using System.Web.Routing;

namespace Momntz.UI.Core.RouteHandler
{
    public class UploadRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new UploadHttpHandler();
        }
    }
}