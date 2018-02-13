using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public static class UnitOfWorkAutofacExtensions
    {
        public static ContainerBuilder AddUnitOfWork<TContext>(this ContainerBuilder services) where TContext : DbContext
        {
            services.Register(c => new UnitOfWork<TContext>(c.Resolve<TContext>())).As<IRepositoryFactory>().InstancePerLifetimeScope();
            // Following has a issue: IUnitOfWork cannot support multiple dbcontext/database, 
            // that means cannot call AddUnitOfWork<TContext> multiple times.
            // Solution: check IUnitOfWork whether or null
            services.Register(c => new UnitOfWork<TContext>(c.Resolve<TContext>())).As<IUnitOfWork>();
            services.Register(c => new UnitOfWork<TContext>(c.Resolve<TContext>())).As<IUnitOfWork<TContext>>();

            return services;
        }
    }
}
