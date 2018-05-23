using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Backend.Web.Facades;
using Backend.Web.Models.Forms;
using FluentValidation;
using Microsoft.Owin;
using Owin;
using System.Reflection;
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

            builder.RegisterControllers(typeof(Startup).Assembly).PropertiesAutowired();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());


            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.EnsureInitialized();

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());

            builder
                .RegisterAssemblyTypes(typeof(FeedbackFormValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterType<ProfileFacade>().As<IProfileFacade>().InstancePerLifetimeScope();
            builder.RegisterType<AlertFacade>().As<IAlertFacade>().InstancePerLifetimeScope();
            builder.RegisterType<FeedbackFacade>().As<IFeedbackFacade>().InstancePerLifetimeScope();
            builder.RegisterType<ReportFacade>().As<IReportFacade>().InstancePerLifetimeScope();
            builder.RegisterType<UserGroupAlertFacade>().As<IUserGroupAlertFacade>().InstancePerLifetimeScope();
            builder.RegisterType<MasterFacade>().As<IMasterFacade>().InstancePerLifetimeScope();

        }
    }
}
