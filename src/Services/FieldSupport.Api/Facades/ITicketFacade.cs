using Astra.Core.Interfaces;
using Astra.Core.Services;
using FieldSupport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldSupport.Api.Facades
{
    public interface ITicketFacade : IBaseFacade<Ticket, TicketSearchContext>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class TicketFacade : BaseFacade<Ticket, TicketSearchContext>, ITicketFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public TicketFacade(IRepository<Ticket> repository): base(repository) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override IQueryable<Ticket> SearchQuery(TicketSearchContext search)
        {
            return _repository.Table.Where(q => true);
        }
    }
}