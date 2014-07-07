using System.Web.Mvc;

namespace AutenticacaoAreas.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            string[] namespaces = new string[] {
                "AutenticacaoAreas.Areas.Admin.Controllers"
            };

            context.MapRoute(
                name: "Admin.Home.Index",
                url: "admin",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Login.Index",
                url: "admin/login",
                defaults: new { controller = "Login", action = "Index" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Admin.Login.Sair",
                url: "admin/deslogar",
                defaults: new { controller = "Login", action = "Sair" },
                namespaces: namespaces
            );
        }
    }
}