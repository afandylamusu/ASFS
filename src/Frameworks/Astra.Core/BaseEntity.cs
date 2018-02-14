using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.Entity
{
    public enum RowStatus : short
    {
        ACTIVE = 0,
        INACTIVE = 1
    }

    public interface IEntity
    {
        int ID { get; set; }
        RowStatus RowStatus { get; set; }
    }

    public abstract class BaseEntity : IEntity
    {
        public virtual int ID { get; set; }

        public RowStatus RowStatus { get; set; }
    }

    public abstract class BaseEntityHistory : BaseEntity, IEntityHistory
    {
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
