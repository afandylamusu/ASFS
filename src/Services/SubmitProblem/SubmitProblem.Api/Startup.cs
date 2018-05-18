using Astra.Facades;
using Autofac;
using Autofac.Integration.WebApi;
using FluentValidation.WebApi;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Newtonsoft.Json.Serialization;
using Owin;
using SubmitProblem.Api.Filters;
using SubmitProblem.Data;
using Swashbuckle.Application;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.OData.Extensions;

[assembly: OwinStartup(typeof(SubmitProblem.Api.Startup))]

namespace SubmitProblem.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var builder = new ContainerBuilder();

            // Run other optional steps, like registering filters,

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterServices(builder);

            var container = builder.Build();

            var webApiConfiguration = ConfigureWebApi(container, app);

            // accept access tokens from identityserver and require a scope of 'api1'
            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "http://localhost:5000",
            //    ValidationMode = ValidationMode.ValidationEndpoint,
            //    RequiredScopes = new[] { "api1" }
            //});

            //app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            //app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
            //    ClientId = "",
            //    ClientSecret = "",
            //    Authority = "",
            //    Scope = "openid"
            //});

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://identity.identityserver.io/oauth2/oidcdiscovery/.well-known/openid-configuration",
                BackchannelHttpHandler = new AccessTokenValidation.Tests.Util.DiscoveryEndpointHandler
                {
                    PreAuthenticate = true,
                    Credentials = new System.Net.NetworkCredential("", "p"),
                },
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new string[] { "openid" }
            });

            // Use the extension method provided by the WebApi.Owin library:
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(webApiConfiguration);
            app.UseWebApi(webApiConfiguration);

            //app.MapSignalR();

            MigrateDatabse(container);
        }

        private void MigrateDatabse(IContainer container)
        {
        }

        private HttpConfiguration ConfigureWebApi(IContainer container, IAppBuilder app)
        {

            var config = new HttpConfiguration();

            // per-controller-type services, etc., then set the dependency resolver
            // to be Autofac.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
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
                c.SingleApiVersion("v1", "Submit Problem API");
                c.IncludeXmlComments(GetXmlCommentsPath());
            }).EnableSwaggerUi();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            //config.Routes.MapHttpRoute(
            //    "MaintenanceAreaRoute",
            //    "api/maintenance/areas",
            //    new { id = RouteParameter.Optional, controller = "MaitenanceAreas" });

            return config;
        }

        private string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\SubmitProblem.Api.xml",
                        System.AppDomain.CurrentDomain.BaseDirectory);
        }


        private void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var context = new SubmitProblemContext();
                return context;
            }).InstancePerApiRequest();

            builder.AddUnitOfWork<SubmitProblemContext>();

            builder.RegisterType<RetrieveInboxHeaderCommand>().As<IRetrieveInboxHeaderCommand>().InstancePerLifetimeScope();
            builder.RegisterType<RequestSubmitProblemCommand>().As<IRequestSubmitProblemCommand>().InstancePerLifetimeScope();
            builder.RegisterType<RequestHistoryCommand>().As<IRequestHistoryCommand>().InstancePerLifetimeScope();
            builder.RegisterType<GetInboxDetailCommand>().As<IGetInboxDetailCommand>().InstancePerLifetimeScope();
            builder.RegisterType<ChangePasswordCommand>().As<IChangePasswordCommand>().InstancePerLifetimeScope();

            builder.RegisterType<ActionSubmitProblemCommand>().As<IActionSubmitProblemCommand>().InstancePerLifetimeScope();

            builder.RegisterType<LoginCommand>().As<ILoginCommand>().InstancePerLifetimeScope();

        }
    }
}
