using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.Projections.Users;

namespace Momntz.UI.Core.RouteConstraints
{
    public class UserRouteConstraint : IRouteConstraint
    {
        private readonly IProjectionHandler<object, IList<ActiveUsername>> _activeUsers;


        public UserRouteConstraint(IProjectionHandler<object, IList<ActiveUsername>> activeUsers)
        {
            _activeUsers = activeUsers;
        }

        /// <summary>
        /// Determines whether the URL parameter contains a valid value for this constraint.
        /// </summary>
        /// <param name="httpContext">
        /// An object that encapsulates information about the HTTP request. </param>
        /// <param name="route">          The object that this constraint belongs to. </param>
        /// <param name="parameterName">  The name of the parameter that is being checked. </param>
        /// <param name="values">         An object that contains the parameters for the URL. </param>
        /// <param name="routeDirection">
        /// An object that indicates whether the constraint check is being performed when an incoming
        /// request is being handled or when a URL is being generated. </param>
        /// <returns> true if the URL parameter contains a valid value; otherwise, false. </returns>
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool isMatch = false;

            if (values.Keys.Contains("username"))
            {
                IList<ActiveUsername> users = _activeUsers.Execute(null);
                var username = Convert.ToString(values["username"]);
                isMatch = users.Any(u => string.Equals(u.Username, username, StringComparison.CurrentCultureIgnoreCase));

            }

            return isMatch;
        }
    }
}