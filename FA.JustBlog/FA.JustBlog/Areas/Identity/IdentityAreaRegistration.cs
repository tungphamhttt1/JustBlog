using System.Web.Mvc;

namespace FA.JustBlog.Areas.Identity
{
    public class IdentityAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Identity";

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "Identity_default",
                "Identity/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}