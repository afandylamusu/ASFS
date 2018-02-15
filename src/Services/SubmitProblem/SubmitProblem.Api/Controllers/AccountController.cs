using Astra.Facades;
using Swashbuckle.Swagger.Annotations;
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
        private readonly IRetrieveInboxHeaderCommand _retrieveInboxHeaderCommand;
        private readonly IChangePasswordCommand _changePasswordCommand;
        private readonly ILoginCommand _loginCommand;

        public AccountController(IRetrieveInboxHeaderCommand retrieveInboxHeaderCommand,
            IChangePasswordCommand changePasswordCommand,
            ILoginCommand loginCommand)
        {
            _retrieveInboxHeaderCommand = retrieveInboxHeaderCommand;
            _changePasswordCommand = changePasswordCommand;
            _loginCommand = loginCommand;
        }


        [Route("login")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommandResult<LoginResult>))]
        public async Task<IHttpActionResult> Login([FromBody] LoginArg args)
        {
            return await Task.FromResult(Ok(_loginCommand.Execute(args)));
        }

        [Route("getinboxheaders")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommandResult<RetrieveInboxHeaderResult>))]
        public async Task<IHttpActionResult> GetInboxHeaders([FromBody]RetrieveInboxHeaderArg args)
        {
            return await Task.FromResult(Ok(_retrieveInboxHeaderCommand.Execute(args)));
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
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CommandResult<ChangePasswordResult>))]
        public async Task<IHttpActionResult> PostChangePassword([FromBody] ChangePasswordArg args)
        {
            return await Task.FromResult(Ok(_changePasswordCommand.Execute(args)));
        }
    }
}