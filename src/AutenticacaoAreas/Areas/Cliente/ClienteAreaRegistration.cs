using System.Web.Mvc;

namespace AutenticacaoAreas.Areas.Cliente
{
    public class ClienteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Cliente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            string[] namespaces = new string[] {
                "AutenticacaoAreas.Areas.Cliente.Controllers"
            };

            context.MapRoute(
                name: "Cliente.Home.Index",
                url: "cliente",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Cliente.Login.Index",
                url: "cliente/login",
                defaults: new { controller = "Login", action = "Index" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Cliente.Login.Sair",
                url: "cliente/deslogar",
                defaults: new { controller = "Login", action = "Sair" },
                namespaces: namespaces
            );
        }
    }
}