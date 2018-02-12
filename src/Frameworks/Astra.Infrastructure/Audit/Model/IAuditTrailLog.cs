using Nest;
using System;

namespace Astra.Infrastructure.AuditTrail.Model
{
    public interface IAuditTrailLog
    {
        DateTime Timestamp { get; set; }

        string GetCustomIndexSuffix();
    }
}
