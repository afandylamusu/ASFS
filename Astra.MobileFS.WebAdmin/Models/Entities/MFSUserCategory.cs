namespace Astra.MobileFS.WebAdmin.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MFSUserCategory")]
    public partial class MFSUserCategory
    {
        public int ID { get; set; }

        public short RowStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public int? DisplayIndex { get; set; }

        public int? UserCategoryGroupID { get; set; }

        public string ImageURL { get; set; }

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

        public virtual MFSUserCategoryGroup MFSUserCategoryGroup { get; set; }
    }
}
