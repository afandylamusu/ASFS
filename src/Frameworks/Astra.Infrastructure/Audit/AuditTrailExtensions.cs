using Astra.Infrastructure.AuditTrail;
using Astra.Infrastructure.AuditTrail.Model;
using Autofac;
using System;

namespace Autofac
{
    public static class AuditTrailExtensions
    {
        public static ContainerBuilder AddAuditTrail<T>(this ContainerBuilder services) where T : class, IAuditTrailLog
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return AddAuditTrail<T>(services, setupAction: null);
        }

        public static ContainerBuilder AddAuditTrail<T>(
            this ContainerBuilder services,
            Action<AuditTrailOptions> setupAction) where T : class, IAuditTrailLog
        {
            var options = new Astra.Core.SharedKernel.Options<AuditTrailOptions>();

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Register<IAuditTrailProvider<T>>(c => new AuditTrailProvider<T>(options)).InstancePerLifetimeScope();

            setupAction?.Invoke(options.Value);

            return services;
        }
    }
}
