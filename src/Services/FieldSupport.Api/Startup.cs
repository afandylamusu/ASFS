using Astra.Core.Interfaces;
using Astra.Infrastructure;
using Astra.Infrastructure.Data;
using Autofac;
using Autofac.Integration.WebApi;
using FieldSupport.Api.Facades;
using FieldSupport.Api.Infrastructure;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(FieldSupport.Api.Startup))]

namespace FieldSupport.Api
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

            var builder = new ContainerBuilder();


            // Run other optional steps, like registering filters,
            RegisterServices(builder);

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<FieldSupportContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //builder.RegisterType<PluginFinder>().As<IPluginFinder>().InstancePerLifetimeScope();

            builder.RegisterType<TicketFacade>().As<ITicketFacade>().InstancePerLifetimeScope();

            var container = builder.Build();

            var webApiConfiguration = ConfigureWebApi(container);

            // Use the extension method provided by the WebApi.Owin library:
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(webApiConfiguration);
            app.UseWebApi(webApiConfiguration);

            app.MapSignalR();
        }

        private void RegisterServices(ContainerBuilder builder)
        {

        }

        private HttpConfiguration ConfigureWebApi(IContainer container)
        {

            var config = new HttpConfiguration();

            // per-controller-type services, etc., then set the dependency resolver
            // to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.


            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "WebAPI");
                c.IncludeXmlComments(GetXmlCommentsPath());
            }).EnableSwaggerUi();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            return config;
        }

        private string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\FieldSupport.Api.xml",
                        System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
