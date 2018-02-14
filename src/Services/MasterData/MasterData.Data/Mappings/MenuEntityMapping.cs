using MasterData.Data.Domain;
using System.Data.Entity.ModelConfiguration;

namespace MasterData.Data.Mappings
{
    internal class MenuEntityMapping : EntityTypeConfiguration<MenuItem>
    {
        public MenuEntityMapping()
        {
            this.ToTable("Menus");
            this.HasKey(p => p.ID);

            this.Property(p => p.Label).HasMaxLength(64).IsRequired();
            this.Property(p => p.RefTypeName).HasMaxLength(128);
        }
    }
}
