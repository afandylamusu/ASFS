using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterData.Data.Domain
{
    [Table("IncidentArea")]
    public partial class IncidentArea : BaseEntityHistory
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? IncidentAreaGroupID { get; set; }

        public int? SeverityNotificationHeaderID { get; set; }

        public int? AssigneeGroupID { get; set; }

        public bool? ToPCSupport { get; set; }
    }
}
