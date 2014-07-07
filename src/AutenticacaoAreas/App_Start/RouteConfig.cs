using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutenticacaoAreas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string[] namespaces = new string[] {
                "AutenticacaoAreas.Controllers"
            };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home.Index",
                url: "",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: namespaces
            );
        }
    }
}
