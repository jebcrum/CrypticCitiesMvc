using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrypticCities
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Voting",
                url: "CrypticCities/Vote/{id}/{approval}",
                defaults: new { controller = "CrypticCities", action = "Vote", id="", approval=""}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CrypticCities", action = "Random", id = UrlParameter.Optional }
            );
        }
    }
}
