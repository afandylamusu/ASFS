using Astra.Infrastructure.Audit;
using Astra.Infrastructure.AuditTrail;
using Astra.Infrastructure.Data;
using System.Data.Entity;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FieldSupport.Api.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class FieldSupportContext : DbContext
    {
        private readonly AuditDbContext _auditContext;
        private readonly IAuditTrailProvider<AuditEntityLog> _auditTrailProvider;

        /// <summary>
        /// 
        /// </summary>
        public FieldSupportContext() : base("DefaultConnection") { }

        /// <summary>
        /// 
        /// </summary>
        public FieldSupportContext(AuditDbContext auditContext) : base("DefaultConnection")
        {
            _auditContext = auditContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auditTrailProvider"></param>
        public FieldSupportContext(IAuditTrailProvider<AuditEntityLog> auditTrailProvider) : base("DefaultConnection")
        {
            _auditTrailProvider = auditTrailProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ApplyEntityTypeConfiguration(Assembly.GetExecutingAssembly());

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var auditEntries = this.OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            if (auditEntries.Count > 0)
                await this.OnAfterSaveChanges(auditEntries, _auditTrailProvider);
            return result;
        }

    }
}