using System;
using System.Web.Mvc;
using System.Web.Security;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Users.Models;
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

        /// <summary>
        /// Creates a <see cref="T:System.Web.Mvc.JsonResult" /> object that serializes the specified object to JavaScript Object Notation (JSON) format using the content type, content encoding, and the JSON request behavior.
        /// </summary>
        /// <param name="data">The JavaScript object graph to serialize.</param>
        /// <param name="contentType">The content type (MIME type).</param>
        /// <param name="contentEncoding">The content encoding.</param>
        /// <param name="behavior">The JSON request behavior</param>
        /// <returns>The result object that serializes the specified object to JSON format.</returns>
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>The username.</value>
        protected string Username
        {
            get {return GetUsername();}
        }

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.Username = Username;
            ViewBag.CurrentLandingPageUsername = CurrentLandingPageUsername();
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>System.String.</returns>
        public string GetDisplayName(string username)
        {
            var processor = ObjectFactory.GetInstance<IProjectionProcessor>();
            var name = processor.Process<string, DisplayName>(username);

            return name.Fullname;
        }

        /// <summary>
        /// Currents the signed in user.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>``0.</returns>
        public T CurrentSignedInUser<T>() where T : ISignedUser, new()
        {
            string landingPageUser = CurrentLandingPageUsername();
            bool isSignedIn = IsAuthenticatedUser(landingPageUser);

            var user = new T
                {
                    Username = landingPageUser,
                    IsAuthenticatedUser = isSignedIn,
                    DisplayName = GetDisplayName(landingPageUser)
                };

            return user;
        }

        /// <summary>
        /// Determines whether [is authenticated user] [the specified name].
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if [is authenticated user] [the specified name]; otherwise, <c>false</c>.</returns>
        public bool IsAuthenticatedUser(string name)
        {
            string username = AuthenticatedUsername();
            return string.Equals(username, name);
        }

        /// <summary>
        /// Authenticateds the username.
        /// </summary>
        /// <returns>System.String.</returns>
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

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetUsername()
        {
            string username = AuthenticatedUsername();

            if(string.IsNullOrEmpty(username))
            {
                username = Convert.ToString(RouteData.Values["username"]);
            }

            return username;
        }

        /// <summary>
        /// Currents the landing page username.
        /// </summary>
        /// <returns>System.String.</returns>
        public string CurrentLandingPageUsername()
        {
            return Convert.ToString(RouteData.Values["username"]);
        }

    }
}