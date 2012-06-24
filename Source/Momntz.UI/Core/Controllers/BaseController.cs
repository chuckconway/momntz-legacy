using System.Web.Mvc;
using System.Web.Security;
using Momntz.UI.Core.ActionResults;

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

        public static string GetUsername()
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
    }
}