using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.OData.Extensions;
using Swashbuckle.Application;
using MasterData.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity;

[assembly: OwinStartup(typeof(MasterData.Api.Startup))]

namespace MasterData.Api
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

            //app.MapSignalR();

            MigrateDatabse(container);
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
            config.MapHttpAttributeRoutes();

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Master Data API");
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
            return System.String.Format(@"{0}\bin\MasterData.Api.xml",
                        System.AppDomain.CurrentDomain.BaseDirectory);
        }


        private void RegisterServices(ContainerBuilder builder)
        {
            builder.Register<MasterDataContext>(c =>
            {
                var context = new MasterDataContext();
                return context;
            }).InstancePerLifetimeScope();

            builder.AddUnitOfWork<MasterDataContext>();
        }

        private void MigrateDatabse(IContainer container)
        {
            var context = container.Resolve<MasterDataContext>();
            //if (!context.Database.Exists())
            //{
            //    throw new Exception("Database migration failed because the target database does not exist. Ensure the database was initialized.");
            //}

            var migrateConfig = new MasterData.Data.Migrations.MasterDataContextConfiguration();
            var migrate = new DbMigrator(migrateConfig);
            migrate.Update();
        }
    }
}
