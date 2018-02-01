using Astra.Core.Interfaces;
using Astra.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Infrastructure.Audit
{
    public class EntityAudit : BaseEntity, IAuditTrail
    {
        public string Entity { get; set; }
        public int Key { get; set; }

        public DateTime _CreatedUtc { get; set; }
        public string _CreatedBy { get; set; }
        public string _CreatedAgent { get; set; }
        public DateTime _LastModifiedUtc { get; set; }
        public string _LastModifiedBy { get; set; }
        public string _LastModifiedAgent { get; set; }
    }
}
