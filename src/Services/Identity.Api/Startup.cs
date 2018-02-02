using Autofac;
using Autofac.Integration.Mvc;
using Identity.Api.Infrastructure;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Owin;
using Owin;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Identity.Api.Startup))]

namespace Identity.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            var builder = new ContainerBuilder();

            // STANDARD MVC SETUP:

            // Register your MVC controllers.
            builder.RegisterControllers(this.GetType().Assembly);

            // Run other optional steps, like registering model binders,
            // web abstractions, etc., then set the dependency resolver
            // to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // OWIN MVC SETUP:

            ConfigureIdentityServer(app);

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureIdentityServer(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                var factory =
                    new IdentityServerServiceFactory().UseInMemoryClients(Clients.Get())
                                                      .UseInMemoryScopes(Scopes.Get());

                var userService = new UserService();


                factory.UserService = new Registration<IUserService>(reslove => userService);

                idsrvApp.UseIdentityServer(
                     new IdentityServerOptions
                     {
                         SiteName = "Standalone Identity Server",
                         SigningCertificate = LoadCertificate(),
                         Factory = factory,

                         RequireSsl = true
                     });
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
              $"{AppDomain.CurrentDomain.BaseDirectory}\\bin\\idsrv3test.pfx", "idsrv3test");
        }
    }
}
