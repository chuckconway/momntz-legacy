using System.Web.Mvc;
using Momntz.Data.Repositories.Users;
using Momntz.UI.Core.RouteConstraints;

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
            var routeContraint = new UserRouteConstraint(DependencyResolver.Current.GetService<IUserRepository>());

            context.MapRoute(
            "Users_albums",
            "{username}/albums/{id}/{name}",
            new { controller = "albums", action = "name", id="id"},
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
            new { controller = "Media", action = "Index" },
            constraints: new { username = routeContraint });

            context.MapRoute(
                "Users_default",
                "{username}/{controller}/{action}/{id}",
                new {  controller = "index", action = "Index", id = UrlParameter.Optional },
                constraints: new { username = routeContraint });
        }
    }
}
