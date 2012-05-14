using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Momntz.Model;

namespace Momntz.UI.Core.RouteConstraints
{
    public class UserRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //UserCache userCache = new UserCache(_userRepository, _cacheProvider);
            IList<User> users; // = userCache.SelectAll();

            return (from user in users
                    from keyValuePair in values
                    where user.Username.Equals(keyValuePair.Value.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    select user).Any();
        }
    }
}