using System.Web.Mvc;
using Momntz.Infrastructure.Processors;
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
            context.MapRoute(
            "Users_albums",
            "{username}/albums/{name}",
            new { controller = "albums", action = "name"},
            constraints: new
            {
                username = new UserRouteConstraint(ObjectFactory.GetInstance<IProjectionProcessor>()),
            });

            context.MapRoute(
            "Users_date",
            "{username}/{year}/{month}/{day}",
            new { controller = "date", action = "Index", month = UrlParameter.Optional, day = UrlParameter.Optional },
            constraints: new
                {
                    username = new UserRouteConstraint(ObjectFactory.GetInstance<IProjectionProcessor>()),
                    year = @"\d{4}"
                });

            context.MapRoute(
            "Users_media",
            "{username}/media/{id}",
            new { controller = "Media", action = "Index" },
            constraints: new { username = new UserRouteConstraint(ObjectFactory.GetInstance<IProjectionProcessor>()) });

            context.MapRoute(
                "Users_default",
                "{username}/{controller}/{action}/{id}",
                new {  controller = "index", action = "Index", id = UrlParameter.Optional }, 
                constraints:new { username = new UserRouteConstraint(ObjectFactory.GetInstance<IProjectionProcessor>()) });


        }
    }
}
