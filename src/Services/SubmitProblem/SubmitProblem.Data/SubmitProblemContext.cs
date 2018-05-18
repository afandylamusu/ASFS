using SubmitProblem.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmitProblem.Data
{
    public partial class SubmitProblemContext : DbContext
    {
        public SubmitProblemContext()
            : base("name=SubmitProblemContext")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<ComplaintAdditionalRating> ComplaintAdditionalRatings { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
