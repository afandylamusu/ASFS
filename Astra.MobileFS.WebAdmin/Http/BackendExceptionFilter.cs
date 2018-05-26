using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Astra.MobileFS.WebAdmin.Http
{
    /// <summary>
    /// 
    /// </summary>
    public class BackendExceptionFilter : System.Web.Http.Filters.ExceptionFilterAttribute, System.Web.Mvc.IExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            
        }

        /// <summary>
        /// Web Api Exception Handler
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(actionExecutedContext.Exception));

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}