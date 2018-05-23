using Backend.Web.Facades;
using Backend.Web.Models;
using Backend.Web.Models.Dtos;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Backend.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/profiles")]
    public class ProfilesController : ApiController
    {
        private readonly IProfileFacade _profileFacade;

        /// <summary>
        /// 
        /// </summary>
        public ProfilesController(IProfileFacade profileFacade)
        {
            _profileFacade = profileFacade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("list/fs")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GenericPageResult<ProfileDto>))]
        public async Task<GenericPageResult<ProfileDto>> ListFS(ODataQueryOptions options)
        {
            var result = _profileFacade.GetUsers(options, true, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }

    }
}