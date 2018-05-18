using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MasterData.Data.Domain
{
    [Table("UserCategories")]
    public partial class UserCategory : BaseEntityHistory
    {
        public string Name { get; set; }
        public int MenuID { get; set; }
    }
}
