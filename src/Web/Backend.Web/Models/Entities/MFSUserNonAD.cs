namespace Backend.Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MFSUserNonAD")]
    public partial class MFSUserNonAD
    {
        public int ID { get; set; }

        public short RowStatus { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string NPK { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string EmailAddress { get; set; }

        [StringLength(30)]
        public string OfficePhone { get; set; }

        [StringLength(10)]
        public string OfficePhoneExt { get; set; }

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
    }
}
