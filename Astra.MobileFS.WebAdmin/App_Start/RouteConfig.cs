using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Astra.MobileFS.WebAdmin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller="Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ReportTicketStatusPrint",
                url: "api/report/ticket-status/print",
                defaults: new { controller = "Report", action = "print-ticket-status", id = UrlParameter.Optional }
            );
        }
    }
}

