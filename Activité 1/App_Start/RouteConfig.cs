using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Activité_1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            

            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Afficher", action = "Afficher"}
            );

            routes.MapRoute(
                name: "Auteurs",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "Auteurs"}
                );

            routes.MapRoute(
                name: "Auteur",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "Auteur", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Livre",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "Livre", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Recherche",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Rechercher", action = "Livre" },
                constraints: new{id = @"[a-zA-Z0-9]*"}
                );




        }
    }
}
