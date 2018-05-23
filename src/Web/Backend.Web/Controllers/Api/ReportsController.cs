using Backend.Web.Facades;
using Backend.Web.Models;
using Backend.Web.Models.Dtos;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Backend.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/report")]
    public class ReportsController : ApiController
    {
        private readonly IReportFacade _reportFacade;

        public ReportsController(IReportFacade reportFacade)
        {
            _reportFacade = reportFacade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("ticket-status")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GenericPageResult<TicketStatusReportItemDto>))]
        public async Task<GenericPageResult<TicketStatusReportItemDto>> TicketStatusReportItems(ODataQueryOptions options)
        {
            var result = _reportFacade.GetTicketStatusReport(options, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[Route("ticket-status/print")]
        //[HttpPost]
        //public async Task<IHttpActionResult> TicketStatusReportItemsPrint([FromBody] int[] ids, bool exclude = false)
        //{
        //    var result = _reportFacade.GetTicketStatusReport(ids);
        //    return Content(HttpStatusCode.Accepted, string.Empty);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedback-user")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GenericPageResult<UserFeedbackReportItemDto>))]
        public async Task<GenericPageResult<UserFeedbackReportItemDto>> UserFeedbackReportItems(ODataQueryOptions options)
        {
            var result = _reportFacade.GetUserFeedbackReport(options, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }
    }
}