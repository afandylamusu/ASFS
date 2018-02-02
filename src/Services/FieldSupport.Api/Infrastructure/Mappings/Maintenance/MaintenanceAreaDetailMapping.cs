using FieldSupport.Domain.Maintenance;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings.Maintenance
{
    public class MaintenanceAreaDetailMapping : EntityTypeConfiguration<MaintenanceAreaDetail>
    {
        public MaintenanceAreaDetailMapping()
        {
            this.ToTable("MaintenanceAreaDetails");
            this.HasKey(p => p.Id);

            this.HasRequired(p => p.Area)
                .WithMany()
                .HasForeignKey(p => p.Area_Id);
        }
    }
}