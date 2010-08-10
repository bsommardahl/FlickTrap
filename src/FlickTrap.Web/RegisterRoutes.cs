using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FlickTrap.Web
{
    public class RegisterRoutes : IBootstrapperTask
    {
        public void Execute()
        {
            var routes = RouteTable.Routes;

            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                "FlickDetails",
                "Flick/Details/{imdbid}",
                new
                    {
                        controller = "Flick",
                        action = "Details"
                    }
                );
            
            //routes.MapRoute("Image", "Image/{width}/{path}", new { controller = "Image", action = "Index" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                } // Parameter defaults
            );
        }
    }
}