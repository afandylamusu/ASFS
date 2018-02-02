using FieldSupport.Domain.Maintenance;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings.Maintenance
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            this.ToTable("Customers");
            this.HasKey(p => p.Id);
        }
    }
}