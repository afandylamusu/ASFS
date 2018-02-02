using FieldSupport.Domain.Maintenance;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings.Maintenance
{
    public class TicketTypeMapping : EntityTypeConfiguration<TicketType>
    {
        public TicketTypeMapping()
        {
            this.ToTable("TicketTypes");
            this.HasKey(p => p.Id);
        }
    }
}