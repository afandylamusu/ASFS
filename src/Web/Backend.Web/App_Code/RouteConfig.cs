using System.Web.Mvc;
using System.Web.Routing;

namespace Backend.Web
{
    public class RouteConfig
    {
        internal static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name 
                "{controller}/{action}/{id}",                           // URL with parameters 
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }
    }
}