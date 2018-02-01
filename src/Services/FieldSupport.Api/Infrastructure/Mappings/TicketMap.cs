using FieldSupport.Domain.Maintenance;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        /// <summary>
        /// 
        /// </summary>
        public TicketMap()
        {
            this.ToTable("Tickets");
            this.HasKey(p => p.Id);

            this.Property(p => p.Title).HasMaxLength(225).IsRequired();
            this.Property(p => p.Description).HasMaxLength(1000).IsRequired();

            this.Property(p => p.Code).HasMaxLength(20).IsRequired();
            
        }
    }
}