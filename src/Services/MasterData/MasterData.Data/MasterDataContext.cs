using System.Data.Entity;

namespace MasterData.Data
{
    public class MasterDataContext : DbContext
    {
        public MasterDataContext()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ApplyEntityTypeConfiguration(typeof(MasterDataContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
