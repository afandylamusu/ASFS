using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Astra.Infrastructure.Data
{
    public static class DbContextExtension
    {
        public static void ApplyEntityTypeConfiguration(this DbModelBuilder modelBuilder, Assembly contextAssembly)
        {
            var typesToRegister = contextAssembly.GetTypes()
                  .Where(type => !String.IsNullOrEmpty(type.Namespace))
                  .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                  && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}
