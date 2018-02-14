using Astra.Facades;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace MasterData.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api")]
    public class CommonController : ApiController
    {
        private readonly IRetrieveMasterDataCommand _retrieveMasterDataCommand;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public CommonController(IRetrieveMasterDataCommand command)
        {
            _retrieveMasterDataCommand = command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("getmasterdata")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(ICommandResult<RetrieveMasterDataResult>))]
        public async Task<IHttpActionResult> GetMasterData([FromBody] MasterDataArguments args)
        {
            return await Task.FromResult(Ok(_retrieveMasterDataCommand.Execute(args)));
        }
    }
}