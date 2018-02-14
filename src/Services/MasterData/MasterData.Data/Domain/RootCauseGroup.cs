namespace MasterData.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("RootCauseGroup")]
    public partial class RootCauseGroup : BaseEntityHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get; set; }

        //public short RowStatus { get; set; }

        public int? IncidentAreaGroupID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
