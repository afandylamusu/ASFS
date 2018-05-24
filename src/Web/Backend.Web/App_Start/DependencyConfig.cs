using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Backend.Web.Facades;
using Backend.Web.Models.Forms;
using FluentValidation;
using System.Reflection;

namespace Backend.Web
{
    internal class DependencyConfig
    {
        internal static IContainer Build()
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);

            builder.RegisterControllers(typeof(Startup).Assembly).PropertiesAutowired();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            return builder.Build();
        }

        private static void RegisterServices(ContainerBuilder builder)
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