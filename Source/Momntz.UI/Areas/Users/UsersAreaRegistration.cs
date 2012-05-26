using System.Web.Mvc;
using Momntz.Infrastructure;
using Momntz.UI.Core;
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
            context.MapRoute(
                "Users_default",
                "{username}/{controller}/{action}/{id}",
                new {  controller = "index", action = "Index", id = UrlParameter.Optional },
                constraints: new {username = new UserRouteConstraint(new ProjectionProcessor(new StructureMapInjection())) });
        }
    }
}
