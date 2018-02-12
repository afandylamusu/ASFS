using Astra.Core.Interfaces;
using Astra.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Infrastructure.Audit
{
    public class EntityAudit : BaseEntity
    {
        public string EntityName { get; set; }
        public int Key { get; set; }
        public string ByUser { get; set; }
        public string Action { get; set; }
        public DateTime RevisionStampUtc { get; set; }
    }
}
