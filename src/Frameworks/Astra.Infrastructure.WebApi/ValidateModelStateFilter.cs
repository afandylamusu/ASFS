using Astra.Facades;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace System.Web.Http
{
    public class InvalidCommandResult : ICommandResult<object>
    {
        public InvalidCommandResult(ModelStateDictionary modelState)
        {
            Data = null;
            Success = false;
            Message = "Argument is Invalid\n" + string.Join("\n ", modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)); 
           
        }

        public object Data { get; private set; }

        public string Message { get; private set; }

        //public IList<ModelErrorCollection> Errors { get; private set; }

        public bool Success { get; private set; }
    }

    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
                actionContext.Response = actionContext.Request.CreateResponse(new InvalidCommandResult(actionContext.ModelState));
            }
        }
    }
}
