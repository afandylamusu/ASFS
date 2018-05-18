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
using Newtonsoft.Json.Serialization;
using Astra.Facades;
using MasterData.Api.Filters;
using Microsoft.Owin.Logging;
using FluentValidation.WebApi;
using IdentityServer3.AccessTokenValidation;

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

            System.Net.ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://192.168.99.100:9443/oauth2/oidcdiscovery/.well-known/openid-configuration",
                //BackchannelHttpHandler = new System.Net.Http.WebRequestHandler()
                //{
                //    PreAuthenticate = true,
                //    Credentials = new System.Net.NetworkCredential("admin", "admin"),
                //    //ClientCertificateOptions = System.Net.Http.ClientCertificateOption.Automatic
                //},
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new string[] { "openid" }
            });

            var container = builder.Build();

            var webApiConfiguration = ConfigureWebApi(container, app);

            // Use the extension method provided by the WebApi.Owin library:
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(webApiConfiguration);
            app.UseWebApi(webApiConfiguration);

            //app.MapSignalR();

            //MigrateDatabse(container);
        }

        private HttpConfiguration ConfigureWebApi(IContainer container, IAppBuilder app)
        {

            var config = new HttpConfiguration
            {

                // per-controller-type services, etc., then set the dependency resolver
                // to be Autofac.
                DependencyResolver = new AutofacWebApiDependencyResolver(container)
            };
            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.

            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            config.AddODataQueryFilter();
            config.MapHttpAttributeRoutes();


            config.Filters.Add(new ValidateModelStateFilter());
            FluentValidationModelValidatorProvider.Configure(config);

            config.Filters.Add(new HttpGlobalExceptionFilter(app.CreateLogger<Startup>()));

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
            builder.RegisterType<MasterDataContext>().InstancePerLifetimeScope();

            builder.AddUnitOfWork<MasterDataContext>();

            builder.RegisterType<MenuService>().As<IMenuService>().InstancePerLifetimeScope();
            builder.RegisterType<RetrieveMasterDataCommand>().As<IRetrieveMasterDataCommand>().InstancePerLifetimeScope();
        }

        private void MigrateDatabse(IContainer container)
        {
            //var context = container.Resolve<MasterDataContext>();
            ////if (!context.Database.Exists())
            ////{
            ////    throw new Exception("Database migration failed because the target database does not exist. Ensure the database was initialized.");
            ////}

            //var migrateConfig = new MasterData.Data.Migrations.MasterDataContextConfiguration();
            //var migrate = new DbMigrator(migrateConfig);
            //migrate.Update();
        }
    }
}
