using Astra.Infrastructure;
using FieldSupport.Api.Facades;
using FieldSupport.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketsController : BaseApiController<ITicketFacade, Ticket, int, TicketSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public TicketsController(ITicketFacade service) : base(service)
        {

        }
    }
}
