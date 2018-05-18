namespace MasterData.Data
{
    using MasterData.Data.Domain;
    using System.Data.Entity;

    public partial class MasterDataContext : DbContext
    {
        public MasterDataContext()
            : base("name=MasterDataContext")
        {
        }

        public virtual DbSet<RootCause> RootCauses { get; set; }
        public virtual DbSet<RootCauseDetail> RootCauseDetails { get; set; }
        public virtual DbSet<RootCauseGroup> RootCauseGroups { get; set; }

        public virtual DbSet<IncidentAreaDetail> IncidentAreaDetails { get; set; }
        public virtual DbSet<IncidentAreaGroup> IncidentAreaGroups { get; set; }
        public virtual DbSet<IncidentArea> IncidentAreas { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<UserCategory> UserCategories { get; set; }
        public virtual DbSet<AdditionalRating> AdditionalRatings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyEntityTypeConfiguration(typeof(MasterDataContext).Assembly);


            modelBuilder.Entity<RootCause>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RootCause>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RootCause>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<RootCause>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<RootCause>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<RootCauseDetail>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseDetail>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseDetail>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseDetail>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<RootCauseGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseGroup>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<RootCauseGroup>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();
        }
    }
}
