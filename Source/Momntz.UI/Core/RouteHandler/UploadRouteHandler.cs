using System.Web;
using System.Web.Routing;

namespace Momntz.UI.Core.RouteHandler
{
    public class UploadRouteHandler : IRouteHandler
    {
        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <returns>An object that processes the request.</returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new UploadHttpHandler();
        }
    }
}