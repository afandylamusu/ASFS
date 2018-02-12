using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
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

        public static IEnumerable<DbPropertyEntry> Properties(this DbEntityEntry entry)
        {
            return entry.CurrentValues.PropertyNames.Select(o => entry.Property(o));
        }


        public static string[] GetKeyNames(this DbContext context, DbEntityEntry entry)
        {
            Type t = entry.Entity.GetType();
            Dictionary<Type, string[]> _dict = new Dictionary<Type, string[]>();

            //retreive the base type
            //while (t.BaseType != typeof(object))
            //{
            //    t = t.BaseType;
            //}

            string[] keys;

            _dict.TryGetValue(t, out keys);
            if (keys != null)
            {
                return keys;
            }

            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            //create method CreateObjectSet with the generic parameter of the base-type
            MethodInfo method = typeof(ObjectContext).GetMethod("CreateObjectSet", Type.EmptyTypes)
                                                     .MakeGenericMethod(t);
            dynamic objectSet = method.Invoke(objectContext, null);

            IEnumerable<dynamic> keyMembers = objectSet.EntitySet.ElementType.KeyMembers;
            string[] keyNames = keyMembers.Select(k => (string)k.Name).ToArray();

            _dict.Add(t, keyNames);

            return keyNames;
        }

    }
}
