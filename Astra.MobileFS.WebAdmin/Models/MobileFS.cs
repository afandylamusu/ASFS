namespace Astra.MobileFS.WebAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Astra.MobileFS.WebAdmin.Models.Entities;

    public partial class MobileFS : DbContext
    {
        public MobileFS()
            : base("name=MobileFSConnection")
        {
        }

        public virtual DbSet<MFSAdditionalRating> MFSAdditionalRatings { get; set; }
        public virtual DbSet<MFSAlert> MFSAlerts { get; set; }
        public virtual DbSet<MFSAlertGroup> MFSAlertGroups { get; set; }
        public virtual DbSet<MFSAlertGroupUser> MFSAlertGroupUsers { get; set; }
        public virtual DbSet<MFSGoogleToken> MFSGoogleTokens { get; set; }
        public virtual DbSet<MFSPICLocation> MFSPICLocations { get; set; }
        public virtual DbSet<MFSUserCategory> MFSUserCategories { get; set; }
        public virtual DbSet<MFSUserCategoryGroup> MFSUserCategoryGroups { get; set; }
        public virtual DbSet<MFSUserNonAD> MFSUserNonADs { get; set; }
        public virtual DbSet<MFSComplaintFeedbackAdditionalRating> MFSComplaintFeedbackAdditionalRatings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MFSAdditionalRating>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAdditionalRating>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAdditionalRating>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAdditionalRating>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAdditionalRating>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSAlert>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlert>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlert>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlert>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlert>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSAlertGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlertGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlertGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlertGroup>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlertGroup>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSAlertGroup>()
                .HasMany(e => e.MFSAlerts)
                .WithRequired(e => e.MFSAlertGroup)
                .HasForeignKey(e => e.AlertGroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MFSAlertGroup>()
                .HasMany(e => e.MFSAlertGroupUsers)
                .WithRequired(e => e.MFSAlertGroup)
                .HasForeignKey(e => e.AlertGroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MFSAlertGroupUser>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlertGroupUser>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSAlertGroupUser>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSGoogleToken>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<MFSGoogleToken>()
                .Property(e => e.GoogleToken)
                .IsUnicode(false);

            modelBuilder.Entity<MFSGoogleToken>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSGoogleToken>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSGoogleToken>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSPICLocation>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<MFSPICLocation>()
                .Property(e => e.Longitude)
                .HasPrecision(15, 6);

            modelBuilder.Entity<MFSPICLocation>()
                .Property(e => e.Latitude)
                .HasPrecision(15, 6);

            modelBuilder.Entity<MFSPICLocation>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSPICLocation>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSPICLocation>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSUserCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategory>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategory>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSUserCategoryGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategoryGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategoryGroup>()
                .Property(e => e.ImageURL)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategoryGroup>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategoryGroup>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserCategoryGroup>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSUserCategoryGroup>()
                .HasMany(e => e.MFSUserCategories)
                .WithOptional(e => e.MFSUserCategoryGroup)
                .HasForeignKey(e => e.UserCategoryGroupID);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.NPK)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.OfficePhone)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.OfficePhoneExt)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSUserNonAD>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();

            modelBuilder.Entity<MFSComplaintFeedbackAdditionalRating>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSComplaintFeedbackAdditionalRating>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MFSComplaintFeedbackAdditionalRating>()
                .Property(e => e.TimeStatus)
                .IsFixedLength();
        }
    }
}
