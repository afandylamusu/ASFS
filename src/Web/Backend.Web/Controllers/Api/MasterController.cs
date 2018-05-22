using Backend.Web.Facades;
using Backend.Web.Models;
using Backend.Web.Models.Forms;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;

namespace Backend.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api")]
    public partial class MasterController : ApiController
    {
        private readonly IFeedbackFacade _feedbackFacade;
        private readonly IUserGroupAlertFacade _userGroupAlertFacade;

        public MasterController(IFeedbackFacade feedbackFacade, IUserGroupAlertFacade userGroupAlertFacade)
        {
            _feedbackFacade = feedbackFacade;
            _userGroupAlertFacade = userGroupAlertFacade;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("feedback/list")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(GenericPageResult<int>))]
        public async Task<GenericPageResult<int>> FeedbackList(ODataQueryOptions options)
        {
            var data = new int[] { 1, 3, 4, 5, 2 };

            var result = data.AsQueryable().ApplyOData(options, out long count);

            return await Task.FromResult(this.ToPageResult<int>(result, count));
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
            var result = await _feedbackFacade.CreateFeedback(form);
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
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(GenericPageResult<int>))]
        public async Task<IHttpActionResult> AlertGroupList()
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("alert-group/create")]
        [HttpPost]
        public async Task<IHttpActionResult> AlertGroupCreate([FromBody] UserGroupAlsertForm form)
        {
            return Ok(await _userGroupAlertFacade.CreateUserGroup(form));
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
    }
}