using Autofac;
using Autofac.Integration.WebApi;
using FieldSupport.Api.Infrastructure;
using FieldSupport.Api.Services;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using System;
using System.Data.Entity.Migrations;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.OData.Extensions;

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

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterServices(builder);

            var container = builder.Build();

            var webApiConfiguration = ConfigureWebApi(container);

            // Use the extension method provided by the WebApi.Owin library:
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(webApiConfiguration);
            app.UseWebApi(webApiConfiguration);

            app.MapSignalR();

            MigrateDatabse(container);
        }

        private void MigrateDatabse(IContainer container)
        {
            var context = container.Resolve<FieldSupportContext>();
            if (!context.Database.Exists())
            {
                throw new Exception("Database migration failed because the target database does not exist. Ensure the database was initialized and seeded with the 'InstallDatabaseInitializer'.");
            }

            var migrateConfig = new Infrastructure.Migrations.Configuration();
            var migrate = new DbMigrator(migrateConfig);
            migrate.Update();
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<FieldSupportContext>().InstancePerLifetimeScope();

            builder.RegisterType<TicketService>().As<ITicketService>().InstancePerLifetimeScope();

        }

        private HttpConfiguration ConfigureWebApi(IContainer container)
        {

            var config = new HttpConfiguration();

            // per-controller-type services, etc., then set the dependency resolver
            // to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.

            config.AddODataQueryFilter();

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Astra Field Support API");
                c.IncludeXmlComments(GetXmlCommentsPath());
            }).EnableSwaggerUi();

            config.MapHttpAttributeRoutes();


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
