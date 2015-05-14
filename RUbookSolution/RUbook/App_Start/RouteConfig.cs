using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RUbook
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.MapRoute("Default", "{controller}/{action}/{id}",
        //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        //    new { controller = "Groups", action = "Create", id = UrlParameter.Optional },
        //    new { }
            
        //    //new { controller = "Home|Settings|General|..." } // this is basically a regular expression
        //    );
        //    routes.MapRoute("NotFound", "{*url}", new { controller = "Error", action = "PageNotFound" });
        //}



        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "404-PageNotFound",
                "{*url}",
                 new { controller = "Error", action = "NotFound" }
                );


        }
    };
}