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
    [Table("IncidentAreaGroup")]
    public partial class IncidentAreaGroup : BaseEntityHistory
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? CompanyID { get; set; }
    }
}
