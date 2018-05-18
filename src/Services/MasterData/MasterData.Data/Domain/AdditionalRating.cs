using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MasterData.Data.Domain
{
    [Table("AdditionalRatings")]
    public partial class AdditionalRating : BaseEntityHistory
    {
        public int ApplicationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
