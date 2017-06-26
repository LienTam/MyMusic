using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMusic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = "A001" }
            );
            routes.MapRoute(
            "Detail",                                              // Route name
            "{controller}/{action}/{idAudio}",                           // URL with parameters
            new { controller = "Home", action = "Detail", id = UrlParameter.Optional }  // Parameter defaults
        );
            routes.MapRoute(
           "Like",                                              // Route name
           "{controller}/{action}/{idPost}/{idUser}",                           // URL with parameters
           new { controller = "Home", action = "Like", idPost = UrlParameter.Optional, idUser=UrlParameter.Optional }  // Parameter defaults

       );
        }
        
    }
}
