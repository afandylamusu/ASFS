using System.Web.Mvc;

namespace Backend.Web
{
    public class FilterConfig
    {
        internal static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}