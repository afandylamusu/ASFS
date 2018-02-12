using Astra.Infrastructure.AuditTrail.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Astra.Infrastructure.Audit
{
    public class AuditEntityLog : IAuditTrailLog
    {
        public string EntityName { get; set; }
        public int EntityKey { get; set; }
        public DateTime Timestamp { get; set; }
        public string ByUser { get; set; }
        public string Action { get; set; }

        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }

        public string GetCustomIndexSuffix()
        {
            return $"{EntityName}-{EntityKey}";
        }
    }

    public class AuditEntry
    {
        public AuditEntry(DbEntityEntry entry)
        {
            Entry = entry;
        }

        public DbEntityEntry Entry { get; }
        public string EntityName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<DbPropertyEntry> TemporaryProperties { get; } = new List<DbPropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public string Action { get; set; }

        public AuditEntityLog ToAudit()
        {
            var audit = new AuditEntityLog
            {
                EntityKey = Convert.ToInt32(KeyValues["Id"]),
                EntityName = EntityName,
                Timestamp = DateTime.UtcNow,
                Action = Action,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues)
            };
            return audit;
        }
    }
}