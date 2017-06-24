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
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            "Audio_detail",                                              // Route name
            "{controller}/{action}/{idAudio}",                           // URL with parameters
            new { controller = "Home", action = "Audio_detail", idAudio = UrlParameter.Optional }  // Parameter defaults
        );
        }
        
    }
}
