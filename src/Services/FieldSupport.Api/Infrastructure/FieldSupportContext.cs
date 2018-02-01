﻿using Astra.Infrastructure.Audit;
using Astra.Infrastructure.Data;
using FieldSupport.Api.Infrastructure.Mappings;
using System.Data.Entity;

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
            modelBuilder.Configurations.Add(new TicketMap());

            modelBuilder.SetAuditEntityConfig();
        }
    }
}