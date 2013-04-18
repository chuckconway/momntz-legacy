using System.Web.Mvc;

namespace Momntz.UI.Areas.Join
{
    public class RegisterAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Join";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Join_default",
                "Join/{controller}/{action}/{id}",
                new {controller="Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
