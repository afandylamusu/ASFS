using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;

namespace FieldSupport.Api.Controllers
{
    [RoutePrefix("api/auth")]
    public class AccountController : ApiController
    {
        [Route("users")]
        public async Task<PageResult<User>> GetUsers(ODataQueryOptions opts)
        {
            ODataQuerySettings querySettings = new ODataQuerySettings()
            {
                PageSize = 100
            };


            var settings = new ODataValidationSettings()
            {
                // Initialize settings as needed.
                AllowedFunctions = AllowedFunctions.None,
                AllowedArithmeticOperators = AllowedArithmeticOperators.None
            };

            opts.Validate(settings);

            var data = new List<User>();


            var results = opts.ApplyTo(data.AsQueryable(), querySettings);

            return new PageResult<User>(
                results as IEnumerable<User>,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }

        [Route("users/{id}")]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            return await Task.FromResult(Ok());
        }

        [Route("users/{id}/change-password")]
        [HttpPost]
        public async Task<IHttpActionResult> ChangePassword()
        {
            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> Login(string username, string password)
        {
            return await Task.FromResult(Ok());
        }

    }

    public class User
    {
    }
}