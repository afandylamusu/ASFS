using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SubmitProblem.Api.Controllers
{
    [RoutePrefix("api")]
    public class TransactionController : ApiController
    {
        [Route("getinboxdetail")]
        [HttpPost]
        public async Task<IHttpActionResult> GetInboxDetail()
        {
            return await Task.FromResult(Ok());
        }

        [Route("postactionsubmitproblem")]
        [HttpPost]
        public async Task<IHttpActionResult> PostActionSubmitProblem()
        {
            return await Task.FromResult(Ok());
        }

        [Route("postrequestsubmitproblem")]
        [HttpPost]
        public async Task<IHttpActionResult> PostRequestSubmitProblem(int? onBehalf = null)
        {
            return await Task.FromResult(Ok());
        }


        [Route("postfeedbacksubmitproblem")]
        [HttpPost]
        public async Task<IHttpActionResult> PostFeedbackSubmitProblem()
        {
            return await Task.FromResult(Ok());
        }

        [Route("postrequesthistory")]
        [HttpPost]
        public async Task<IHttpActionResult> PostRequestHistory()
        {
            return await Task.FromResult(Ok());
        }
    }
}