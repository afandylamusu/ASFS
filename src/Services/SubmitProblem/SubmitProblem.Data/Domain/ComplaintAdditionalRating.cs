using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SubmitProblem.Data.Domain
{
    [Table("ComplaintAdditionalRatings")]
    public partial class ComplaintAdditionalRating : BaseEntityHistory
    {
        public int ComplaintFeedbackID { get; set; }
        public int FeedbackOptionID { get; set; }
    }
}
