namespace Backend.Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MFSAlertGroupUser")]
    public partial class MFSAlertGroupUser
    {
        public int ID { get; set; }

        public short RowStatus { get; set; }

        public int AlertGroupID { get; set; }

        public int ProfileID { get; set; }

        [Required]
        [StringLength(96)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(96)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStatus { get; set; }

        public virtual MFSAlertGroup MFSAlertGroup { get; set; }
    }
}
