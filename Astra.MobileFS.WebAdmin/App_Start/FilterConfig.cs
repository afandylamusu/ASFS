using Astra.MobileFS.WebAdmin.Http;
using System.Web;
using System.Web.Mvc;

namespace Astra.MobileFS.WebAdmin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new BackendExceptionFilter());
        }
    }
}
