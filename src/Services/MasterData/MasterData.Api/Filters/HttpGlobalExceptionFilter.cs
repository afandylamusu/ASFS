using Astra;
using Microsoft.Owin.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MasterData.Api.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpGlobalExceptionFilter : FilterAttribute, IExceptionFilter
    {
        private readonly ILogger _logger;

        public HttpGlobalExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                if(actionExecutedContext.Exception.GetType() == typeof(AstraException))
                {
                    string message = "web service error";
                    var oldObjectContent = (actionExecutedContext.ActionContext.Response.Content as ObjectContent);

                    actionExecutedContext.Response.Content = new ObjectContent<string>(message, oldObjectContent.Formatter);

                    _logger.WriteError(message, actionExecutedContext.Exception);
                }


            }, cancellationToken);
        }
    }
}