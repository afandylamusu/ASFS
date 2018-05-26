using Astra.MobileFS.WebAdmin.Facades;
using Astra.MobileFS.WebAdmin.Models;
using Astra.MobileFS.WebAdmin.Models.Dtos;
using Astra.MobileFS.WebAdmin.Models.Forms;
using Swashbuckle.Swagger.Annotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Astra.MobileFS.WebAdmin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api")]
    public partial class MasterController : ApiController
    {
        private readonly IFeedbackFacade _feedbackFacade;
        private readonly IUserGroupAlertFacade _userGroupAlertFacade;
        private readonly IMasterFacade _masterFacade;

        public MasterController(IFeedbackFacade feedbackFacade, IUserGroupAlertFacade userGroupAlertFacade, IMasterFacade masterFacade)
        {
            _feedbackFacade = feedbackFacade;
            _userGroupAlertFacade = userGroupAlertFacade;
            _masterFacade = masterFacade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedback/list")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(GenericPageResult<FeedbackDto>))]
        public async Task<GenericPageResult<FeedbackDto>> FeedbackList(ODataQueryOptions options)
        {
            var result = _feedbackFacade.GetFeedbacks(options, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedback/create")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GenericResponse))]
        public async Task<IHttpActionResult> FeedbackCreate([FromBody] FeedbackForm form)
        {
            var result = await _feedbackFacade.CreateFeedbackAsync(form);
            var response = new GenericResponse() { Success = result };
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedback/{id:int}")]
        [HttpPost]
        public async Task<IHttpActionResult> FeedbackDetail(int id)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedback/{id:int}/update")]
        [HttpPost]
        public async Task<IHttpActionResult> FeedbackUpdate(int id, [FromBody] FeedbackForm form)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedback/{id:int}/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> FeedbackDelete(int id)
        {
            return await Task.FromResult(Ok());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("alert-group/list")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(GenericPageResult<UserGroupAlertDto>))]
        public async Task<GenericPageResult<UserGroupAlertDto>> AlertGroupList(ODataQueryOptions options)
        {
            var result = _userGroupAlertFacade.GetUserGroups(options, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("alert-group/create")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(GenericResponse))]
        public async Task<IHttpActionResult> AlertGroupCreate([FromBody] UserGroupAlsertForm form)
        {
            var result = await _userGroupAlertFacade.CreateUserGroupAsync(form);
            return Ok(new GenericResponse<int>() { Data = result, Success = true });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("alert-group/{id:int}")]
        [HttpPost]
        public async Task<IHttpActionResult> AlertGroupDetail(int id)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("alert-group/{id:int}/update")]
        [HttpPost]
        public async Task<IHttpActionResult> AlertGroupUpdate(int id, [FromBody] UserGroupAlsertForm form)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("alert-group/{id:int}/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> AlertGroupDelete(int id)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("application/list")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(GenericPageResult<ApplicationDto>))]
        public async Task<GenericPageResult<ApplicationDto>> ApplicationList(ODataQueryOptions options)
        {
            var result = _masterFacade.GetApplications(options, out long count);
            return await Task.FromResult(this.ToPageResult(result, count));
        }
    }
}