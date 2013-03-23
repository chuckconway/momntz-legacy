using System;
using System.Web.Mvc;
using System.Web.Security;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Core.ActionResults;
using StructureMap;

namespace Momntz.UI.Core.Controllers
{
    public class BaseController : Controller
    {
        /// <summary> Queries. </summary>
        /// <typeparam name="TArgs">   Type of the arguments. </typeparam>
        /// <typeparam name="TReturn"> Type of the return. </typeparam>
        /// <param name="args">    The arguments. </param>
        /// <param name="success"> The success. </param>
        /// <returns> . </returns>
        protected ActionResult Query<TArgs, TReturn>(TArgs args, ActionResult success)
        {
            return new QueryResult<TArgs, TReturn>(args, success, View());
        }

        /// <summary> Forms. </summary>
        /// <typeparam name="TArgs"> Type of the arguments. </typeparam>
        /// <param name="args">    The arguments. </param>
        /// <param name="success"> The success. </param>
        /// <returns> . </returns>
        protected ActionResult Form<TArgs>(TArgs args, ActionResult success)
        {
            return new FormResult<TArgs>(args, success, View());
        }

        protected string Username
        {
            get {return GetUsername();}
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Username = Username;
            ViewBag.CurrentLandingPageUsername = CurrentLandingPageUsername();
            base.OnActionExecuting(filterContext);
        }

        public static string GetDisplayName(string username)
        {
            var processor = ObjectFactory.GetInstance<IProjectionProcessor>();
            var name = processor.Process<string, DisplayName>(username);

            return name.Fullname;
        }

        public static bool IsAuthenticatedUser(string name)
        {
            string username = AuthenticatedUsername();
            return string.Equals(username, name);
        }

        public static string AuthenticatedUsername()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            string username = string.Empty;

            if (cookie != null)
            {
                string cookieValue = cookie.Value;
                var ticket = FormsAuthentication.Decrypt(cookieValue);
                username = ticket.Name;
            }

            return username;
        }

        public string GetUsername()
        {
            string username = AuthenticatedUsername();

            if(string.IsNullOrEmpty(username))
            {
                username = Convert.ToString(RouteData.Values["username"]);
            }

            return username;
        }

        public string CurrentLandingPageUsername()
        {
            return Convert.ToString(RouteData.Values["username"]);
        }

    }
}