using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers.Users;

namespace Momntz.UI.Core.Binders
{
    public class UsernameAndPasswordModelBinder : IModelBinder 
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string username = controllerContext.RequestContext.HttpContext.Request["username"];
            string password = controllerContext.RequestContext.HttpContext.Request["password"];
            UsernameAndPassword creds = new UsernameAndPassword(username, password);

            return creds; 

        }
    }
}