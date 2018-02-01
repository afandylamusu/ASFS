using Astra.Infrastructure;
using FieldSupport.Api.Services;
using FieldSupport.Domain.Maintenance;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/tickets")]
    public class TicketsController : BaseApiController<ITicketService, Ticket, int, TicketSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public TicketsController(ITicketService service) : base(service)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <param name="isOwner"></param>
        /// <returns></returns>
        [Route("{id}/done")]
        [HttpPost]
        public async Task<IHttpActionResult> Done(int id, int employeeId, bool isOwner)
        {
           
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Route("{id}/transfer")]
        [HttpPost]
        public async Task<IHttpActionResult> Transfer(int id, int employeeId)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Route("{id}/escalate")]
        [HttpPost]
        public async Task<IHttpActionResult> Escalate(int id, int employeeId)
        {
            return await Task.FromResult(Ok());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Route("{id}/re-open")]
        [HttpPost]
        public async Task<IHttpActionResult> ReOpen(int id, int employeeId)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Route("{id}/on-behalf")]
        [HttpPost]
        public async Task<IHttpActionResult> OnBehalf(int id, int employeeId)
        {
            return await Task.FromResult(Ok());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}/expire")]
        [HttpPost]
        public async Task<IHttpActionResult> Expire(int id)
        {
            return await Task.FromResult(Ok());
        }
    }
}
