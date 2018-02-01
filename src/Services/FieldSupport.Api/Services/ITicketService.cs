using Astra.Core.Interfaces;
using Astra.Infrastructure.Data;
using FieldSupport.Api.Infrastructure;
using FieldSupport.Domain.Maintenance;
using System.Linq;

namespace FieldSupport.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITicketService : IBaseFacade<Ticket, TicketSearchContext>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class TicketService : BaseFacade<Ticket, TicketSearchContext>, ITicketService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TicketService(FieldSupportContext context) : base(context) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override IQueryable<Ticket> SearchQuery(TicketSearchContext search)
        {
            return EntitySet.Where(q => true);
        }
    }
}