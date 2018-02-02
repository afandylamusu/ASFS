using FieldSupport.Domain.Maintenance;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FieldSupport.Api.Infrastructure.Mappings.Maintenance
{
    public class MaintenanceAreaMapping : EntityTypeConfiguration<MaintenanceArea>
    {
        public MaintenanceAreaMapping()
        {
            this.ToTable("MaintenanceAreas");
            this.HasKey(p => p.Id);
        }
    }
}