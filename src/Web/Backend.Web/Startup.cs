using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Astra.Infrastructure;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Backend.Web.Startup))]

namespace Backend.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            EngineContext.Initialize(false);

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
