using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Backend.Web.Facades;
using Microsoft.Owin;
using Owin;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Backend.Web.Startup))]

namespace Backend.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var builder = new ContainerBuilder();

            RegisterServices(builder);

            builder.RegisterControllers(typeof(Startup).Assembly);

            WebApiConfig.Register(app, builder);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.EnsureInitialized();

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);

            app.UseAutofacWebApi(GlobalConfiguration.Configuration);
            app.UseWebApi(GlobalConfiguration.Configuration);

            app.UseAutofacMvc();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());

            builder.RegisterType<AlertFacade>().As<IAlertFacade>().InstancePerLifetimeScope();
        }
    }
}
