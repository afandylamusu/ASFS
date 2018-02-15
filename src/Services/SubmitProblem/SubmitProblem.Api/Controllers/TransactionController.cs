using Astra.Facades;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SubmitProblem.Api.Controllers
{
    [RoutePrefix("api")]
    public class TransactionController : ApiController
    {
        private readonly IGetInboxDetailCommand _getInboxDetailCommand;
        private readonly IActionSubmitProblemCommand _actionSubmitProblemCommand;
        private readonly IRequestSubmitProblemCommand _requestSubmitProblemCommand;
        private readonly IRequestHistoryCommand _requestHistoryCommand;

        public TransactionController(IGetInboxDetailCommand getInboxDetailCommand, 
            IActionSubmitProblemCommand actionSubmitProblemCommand,
            IRequestSubmitProblemCommand requestSubmitProblemCommand,
            IRequestHistoryCommand requestHistoryCommand)
        {
            _getInboxDetailCommand = getInboxDetailCommand;
            _actionSubmitProblemCommand = actionSubmitProblemCommand;
            _requestSubmitProblemCommand = requestSubmitProblemCommand;
            _requestHistoryCommand = requestHistoryCommand;
        }

        [Route("getinboxdetail")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommandResult<GetInboxDetailResult>))]
        public async Task<IHttpActionResult> GetInboxDetail([FromBody] GetInboxDetailArg args)
        {
            return await Task.FromResult(Ok(_getInboxDetailCommand.Execute(args)));
        }

        [Route("postactionsubmitproblem")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommandResult<ActionSubmitProblemResult>))]
        public async Task<IHttpActionResult> PostActionSubmitProblem([FromBody] ActionSubmitProblemArg args)
        {
            return await Task.FromResult(Ok(_actionSubmitProblemCommand.Execute(args)));
        }

        [Route("postrequestsubmitproblem")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommandResult<RequestSubmitProblemResult>))]
        public async Task<IHttpActionResult> PostRequestSubmitProblem([FromBody] RequestSubmitProblemArg args)
        {
            return await Task.FromResult(Ok(_requestSubmitProblemCommand.Execute(args)));
        }


        [Route("postfeedbacksubmitproblem")]
        [HttpPost]
        public async Task<IHttpActionResult> PostFeedbackSubmitProblem()
        {
            return await Task.FromResult(Ok());
        }

        [Route("postrequesthistory")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommandResult<RequestHistoryResult>))]
        public async Task<IHttpActionResult> PostRequestHistory([FromBody] RequestHistoryArg args)
        {
            return await Task.FromResult(Ok(_requestHistoryCommand.Execute(args)));
        }
    }
}