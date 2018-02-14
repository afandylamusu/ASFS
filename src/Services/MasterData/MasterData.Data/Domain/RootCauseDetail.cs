namespace MasterData.Data.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("RootCauseDetail")]
    public partial class RootCauseDetail : BaseEntityHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int ID { get; set; }

        //public short RowStatus { get; set; }

        public int? RootCauseID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? SLA { get; set; }

        public bool? IsMPC { get; set; }

        public bool? IsNPC { get; set; }
    }
}
