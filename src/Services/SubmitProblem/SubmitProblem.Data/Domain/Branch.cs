using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SubmitProblem.Data.Domain
{
    [Table("Branches")]
    public partial class Branch : BaseEntityHistory
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int SalesOrgID { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}
