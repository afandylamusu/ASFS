using Astra.Infrastructure.Audit;
using Astra.Infrastructure.Data;
using FieldSupport.Api.Infrastructure.Mappings;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace FieldSupport.Api.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class FieldSupportContext : MainDbContext
    {

        /// <summary>
        /// 
        /// </summary>
        public FieldSupportContext() : base("DefaultConnection")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ApplyEntityTypeConfiguration(Assembly.GetExecutingAssembly());

            modelBuilder.SetAuditEntityConfig();
        }
    }
}