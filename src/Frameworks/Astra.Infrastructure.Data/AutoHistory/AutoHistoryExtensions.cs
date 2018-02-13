using Astra;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    /// <summary>
    /// Represents a plugin for Microsoft.EntityFrameworkCore to support automatically recording data changes history.
    /// </summary>
    public static class AutoHistoryDbContextExtensions
    {
        private static JsonSerializer _jsonerializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        });

        /// <summary>
        /// Ensures the automatic history.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void EnsureAutoHistory(this DbContext context)
        {
            // Must ToArray() here for excluding the AutoHistory model.
            // Currently, only support Modified and Deleted entity.
            var entries = context.ChangeTracker.Entries().Where(e => e.Entity is IAuditTrail).ToArray();
            foreach (var entry in entries)
            {
                //context.Add(entry.AutoHistory());
                //context.Set<AutoHistory>().Add(entry.AutoHistory());
            }
        }

        //internal static AutoHistory AutoHistory(this DbEntityEntry entry)
        //{
        //    var history = new AutoHistory
        //    {
        //        TableName = entry.Metadata.Relational().TableName,
        //    };

        //    // Get the mapped properties for the entity type.
        //    // (include shadow properties, not include navigations & references)
        //    var properties = entry.Properties();

        //    var json = new JObject();
        //    switch (entry.State)
        //    {
        //        case EntityState.Added:
        //            foreach (var prop in properties)
        //            {
        //                if (prop.Metadata.IsKey() || prop.Metadata.IsForeignKey())
        //                {
        //                    continue;
        //                }
        //                json[prop.Name] = prop.CurrentValue != null
        //                    ? JToken.FromObject(prop.CurrentValue, _jsonerializer)
        //                    : JValue.CreateNull();
        //            }

        //            // REVIEW: what's the best way to set the RowId?
        //            history.RowId = "0";
        //            history.Kind = EntityState.Added;
        //            history.Changed = json.ToString();
        //            break;
        //        case EntityState.Modified:
        //            var bef = new JObject();
        //            var aft = new JObject();

        //            foreach (var prop in properties)
        //            {
        //                if (prop.IsModified)
        //                {
        //                    bef[prop.Name] = prop.OriginalValue != null
        //                    ? JToken.FromObject(prop.OriginalValue, _jsonerializer)
        //                    : JValue.CreateNull();

        //                    aft[prop.Name] = prop.CurrentValue != null
        //                    ? JToken.FromObject(prop.CurrentValue, _jsonerializer)
        //                    : JValue.CreateNull();
        //                }
        //            }

        //            json["before"] = bef;
        //            json["after"] = aft;

        //            history.RowId = entry.PrimaryKey();
        //            history.Kind = EntityState.Modified;
        //            history.Changed = json.ToString();
        //            break;
        //        case EntityState.Deleted:
        //            foreach (var prop in properties)
        //            {
        //                json[prop.Name] = prop.OriginalValue != null
        //                    ? JToken.FromObject(prop.OriginalValue, _jsonerializer)
        //                    : JValue.CreateNull();
        //            }
        //            history.RowId = entry.PrimaryKey();
        //            history.Kind = EntityState.Deleted;
        //            history.Changed = json.ToString();
        //            break;
        //        case EntityState.Detached:
        //        case EntityState.Unchanged:
        //        default:
        //            throw new NotSupportedException("AutoHistory only support Deleted and Modified entity.");
        //    }

        //    return history;
        //}

        //private static string PrimaryKey(this DbEntityEntry entry)
        //{
        //    var key = entry.Metadata.FindPrimaryKey();

        //    var values = new List<object>();
        //    foreach (var property in key.Properties)
        //    {
        //        var value = entry.Property(property.Name).CurrentValue;
        //        if (value != null)
        //        {
        //            values.Add(value);
        //        }
        //    }

        //    return string.Join(",", values);
        //}
    }
}
