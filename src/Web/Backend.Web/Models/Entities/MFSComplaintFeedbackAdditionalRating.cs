namespace Backend.Web.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MFSComplaintFeedbackAdditionalRating")]
    public partial class MFSComplaintFeedbackAdditionalRating
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short RowStatus { get; set; }

        public int? ComplaintFeedbackID { get; set; }

        public int? AdditionalRatingID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(96)]
        public string CreatedBy { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreatedOn { get; set; }

        [StringLength(96)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStatus { get; set; }
    }
}
