using System.Web.Mvc;
using Momntz.Data.Repositories.Users.Parameters;

namespace Momntz.UI.Core.Binders
{
    public class UsernameAndPasswordModelBinder : IModelBinder 
    {
        /// <summary>
        /// Binds the model to a value by using the specified controller context and binding context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The bound value.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string username = controllerContext.RequestContext.HttpContext.Request["username"];
            string password = controllerContext.RequestContext.HttpContext.Request["password"];
            var creds = new UsernameAndPassword(username, password);

            return creds; 
        }
    }
}