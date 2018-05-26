using Astra.MobileFS.WebAdmin.Facades;
using Astra.MobileFS.WebAdmin.Models;
using Astra.MobileFS.WebAdmin.Models.Dtos;
using Swashbuckle.Swagger.Annotations;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Astra.MobileFS.WebAdmin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/alert")]
    public class AlertsController : ApiController
    {
        private readonly IAlertFacade _alertFacade;

        /// <summary>
        /// 
        /// </summary>
        public AlertsController(IAlertFacade alertFacade)
        {
            _alertFacade = alertFacade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("list")]
        [HttpPost]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(GenericPageResult<NewsDto>))]
        public async Task<GenericPageResult<NewsDto>> AlertList(ODataQueryOptions options)
        {
            var result = _alertFacade.Find(options, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("recipients")]
        [HttpPost]
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(GenericPageResult<RecipientDto>))]
        public async Task<GenericPageResult<RecipientDto>> AlertRecipients(string keyword, ODataQueryOptions options)
        {
            var result = _alertFacade.GetRecipients(options, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }
    }
}