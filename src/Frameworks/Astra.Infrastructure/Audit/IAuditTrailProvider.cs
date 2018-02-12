using Astra.Infrastructure.AuditTrail.Model;
using System.Collections.Generic;

namespace Astra.Infrastructure.AuditTrail
{
     public interface IAuditTrailProvider<T>
     {
        void AddLog(T auditTrailLog);

        IEnumerable<T> QueryAuditLogs(string filter = "*", AuditTrailPaging auditTrailPaging = null);

        long Count(string filter);
    }
}
