using FieldSupport.Domain.Maintenance;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings.Maintenance
{
    public class MaintenanceGroupMapping : EntityTypeConfiguration<MaintenanceGroup>
    {
        public MaintenanceGroupMapping()
        {
            this.ToTable("MaintenanceGroups");
            this.HasKey(p => p.Id);
        }
    }
}