using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SubmitProblem.Api.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> Login()
        {
            return await Task.FromResult(Ok());
        }

        [Route("getinboxheaders")]
        [HttpPost]
        public async Task<IHttpActionResult> GetInboxHeaders()
        {
            return await Task.FromResult(Ok());
        }

        [Route("syncgoogletoken")]
        [HttpPost]
        public async Task<IHttpActionResult> SyncGoogleToken()
        {
            return await Task.FromResult(Ok());
        }

        [Route("getmenuitems")]
        [HttpPost]
        public async Task<IHttpActionResult> GetMenuItems()
        {
            return await Task.FromResult(Ok());
        }

        [Route("postchangepassword")]
        [HttpPost]
        public async Task<IHttpActionResult> PostChangePassword()
        {
            return await Task.FromResult(Ok());
        }
    }
}