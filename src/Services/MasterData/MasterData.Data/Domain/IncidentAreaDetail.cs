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
    [Table("IncidentAreaDetail")]
    public partial class IncidentAreaDetail : BaseEntityHistory
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int IncidentAreaID { get; set; }
        
        public int? SOPOutputHeaderID { get; set; }

        public int? IncidentSLA { get; set; }

        public bool? RRTNotification { get; set; }
    }
}
