using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaDeEsporte.Presentation.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new { controller = "Produto", action = "Index", categoria = (string)null, pagina = 1 }
            );

            routes.MapRoute(null,
                "Pagina{pagina}",
                new { controller = "Produto", action = "Index", categoria = (string)null },
                new { pagina = @"\d+" }
            );

            routes.MapRoute(null,
                "{categoria}",
                new { controller = "Produto", action = "Index", pagina = 1 }
            );

            routes.MapRoute(null,
                "{categoria}/Pagina{pagina}",
                new { controller = "Produto", action = "Index" },
                new { pagina = @"\d+" }
            );

            routes.MapRoute(
                name: null,
                url: "Pagina{pagina}",
                defaults: new { controller = "Produto", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produto", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}