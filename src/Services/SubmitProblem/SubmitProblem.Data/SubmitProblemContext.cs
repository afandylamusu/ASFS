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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
