using System;
using System.Web.Mvc;

namespace Momntz.UI.Core.ActionFilters
{
    public class ApiAuthorization : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <exception cref="System.Exception"></exception>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string key = filterContext.HttpContext.Request.QueryString["key"];

            if(string.IsNullOrEmpty(key))
            {
                throw new Exception("Invalid api key");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}