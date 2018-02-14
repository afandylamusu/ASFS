namespace MasterData.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MasterData.Data.Domain;

    public partial class MasterDataContext : DbContext
    {
        public MasterDataContext()
            : base("name=MasterDataContext")
        {
        }

        public virtual DbSet<RootCause> RootCauses { get; set; }
        public virtual DbSet<RootCauseDetail> RootCauseDetails { get; set; }
        public virtual DbSet<RootCauseGroup> RootCauseGroups { get; set; }

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
