namespace Astra.MobileFS.WebAdmin.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MFSGoogleToken")]
    public partial class MFSGoogleToken
    {
        public int ID { get; set; }

        public short RowStatus { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        [Required]
        public string GoogleToken { get; set; }

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
