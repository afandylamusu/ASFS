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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? CompanyID { get; set; }

        public int? UserCategoriesID { get; set; }
    }
}
