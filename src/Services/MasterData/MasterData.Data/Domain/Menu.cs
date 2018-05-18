using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MasterData.Data.Domain
{
    [Table("Menus")]
    public partial class Menu : BaseEntityHistory
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
