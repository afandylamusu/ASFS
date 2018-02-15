using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.OData.Extensions;
using Swashbuckle.Application;
using Newtonsoft.Json.Serialization;
using SubmitProblem.Data;
using System.Data.Entity;
using Astra.Facades;
using FluentValidation.WebApi;

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

            var webApiConfiguration = ConfigureWebApi(container);

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

        private HttpConfiguration ConfigureWebApi(IContainer container)
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
            }).InstancePerLifetimeScope();

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
