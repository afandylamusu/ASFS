namespace MasterData.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class MasterDataContextConfiguration : DbMigrationsConfiguration<MasterData.Data.MasterDataContext>
    {
        public MasterDataContextConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MasterData.Data.MasterDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
