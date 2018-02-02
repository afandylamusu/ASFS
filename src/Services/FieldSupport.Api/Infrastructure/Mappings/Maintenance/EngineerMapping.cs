using FieldSupport.Domain.Maintenance;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings.Maintenance
{
    public class EngineerMapping : EntityTypeConfiguration<Engineer>
    {
        public EngineerMapping()
        {
            this.ToTable("Engineers");
            this.HasKey(p => p.Id);
        }
    }
}