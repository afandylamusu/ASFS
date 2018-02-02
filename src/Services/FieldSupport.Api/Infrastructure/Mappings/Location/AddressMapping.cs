using FieldSupport.Domain.Location;
using System.Data.Entity.ModelConfiguration;

namespace FieldSupport.Api.Infrastructure.Mappings.Location
{
    public class AddressMapping : EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {
            this.ToTable("Addresses");
            this.HasKey(p => p.Id);

            this.Property(p => p.Name).HasMaxLength(128).IsRequired();
        }
    }
}