using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace n01629153Cumulative1
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

            // Added new routes for the pages to navigate for teachers section
            routes.MapRoute(
                name: "ListRoute",
                url: "Teacher/List",
                defaults: new { controller = "Teacher", action = "List"}
            );

            routes.MapRoute(
                name: "ShowRoute",
                url: "Teacher/Show",
                defaults: new { controller = "Teacher", action = "Show" }
            );
        }
    }
}
