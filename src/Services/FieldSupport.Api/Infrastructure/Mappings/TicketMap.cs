using FieldSupport.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FieldSupport.Api.Infrastructure.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        /// <summary>
        /// 
        /// </summary>
        public TicketMap()
        {
            this.ToTable("Tickets");
            this.HasKey(p => p.Id);
            
        }
    }
}