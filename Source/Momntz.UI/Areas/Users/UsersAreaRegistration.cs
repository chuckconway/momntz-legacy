using System.Collections.Generic;
using System.Web.Mvc;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.Projections.Users;
using Momntz.UI.Core.RouteConstraints;
using StructureMap;

namespace Momntz.UI.Areas.Users
{
    public class UsersAreaRegistration : AreaRegistration
    {

        public override string AreaName
        {
            get
            {
                return "Users";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var routeContraint = new UserRouteConstraint(ObjectFactory.GetInstance<IProjectionHandler<object, IList<ActiveUsername>>>());

            context.MapRoute(
            "Users_albums",
            "{username}/albums/{name}",
            new { controller = "albums", action = "name"},
            constraints: new
            {
                username = routeContraint,
            });

            context.MapRoute(
            "Users_date",
            "{username}/{year}/{month}/{day}",
            new { controller = "date", action = "Index", month = UrlParameter.Optional, day = UrlParameter.Optional },
            constraints: new
                {
                    username = routeContraint,
                    year = @"\d{4}"
                });

            context.MapRoute(
            "Users_media",
            "{username}/media/{id}",
            new { controller = "MediaMessage", action = "Index" },
            constraints: new { username = routeContraint });

            context.MapRoute(
                "Users_default",
                "{username}/{controller}/{action}/{id}",
                new {  controller = "index", action = "Index", id = UrlParameter.Optional },
                constraints: new { username = routeContraint });


        }
    }
}
