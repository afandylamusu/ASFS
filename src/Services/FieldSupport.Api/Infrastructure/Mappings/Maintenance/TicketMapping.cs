using FieldSupport.Domain.Maintenance;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketMapping : EntityTypeConfiguration<Ticket>
    {
        /// <summary>
        /// 
        /// </summary>
        public TicketMapping()
        {
            this.ToTable("Tickets");
            this.HasKey(p => p.Id);

            this.Property(p => p.Title).HasMaxLength(225).IsRequired();
            this.Property(p => p.Description).HasMaxLength(1000).IsRequired();

            this.Property(p => p.Code).HasMaxLength(20).IsRequired();

            this.HasRequired(p => p.Owner)
                            .WithMany()
                            .HasForeignKey(p => p.Owner_Id)
                            .WillCascadeOnDelete(false);

            this.HasOptional(p => p.AssignTo)
                .WithMany()
                .HasForeignKey(p => p.AssignTo_Id)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.Address)
                .WithMany()
                .HasForeignKey(p => p.Address_Id)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.Group_Id)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.TicketType)
                .WithMany()
                .HasForeignKey(p => p.TicketType_Id)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.Area)
                .WithMany()
                .HasForeignKey(p => p.Area_Id)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.AreaDetail)
                .WithMany()
                .HasForeignKey(p => p.AreaDetail_Id)
                .WillCascadeOnDelete(false);



        }
    }
}