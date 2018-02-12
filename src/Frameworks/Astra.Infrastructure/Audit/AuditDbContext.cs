using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Infrastructure.Audit
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext() : base("AuditTrailConnection")
        {

        }

        public DbSet<EntityAudit> Audits { get { return Set<EntityAudit>(); } }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var builder = modelBuilder.Entity<EntityAudit>();
            builder.ToTable($"EntityAudits");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.EntityName).HasMaxLength(128).IsRequired();
            builder.Property(p => p.ByUser).HasMaxLength(128).IsRequired();
            builder.Property(p => p.Action).HasMaxLength(16).IsRequired();
            builder.Property(p => p.RevisionStampUtc).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
