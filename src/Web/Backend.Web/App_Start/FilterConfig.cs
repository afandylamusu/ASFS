﻿using Backend.Web.Http;
using System.Web;
using System.Web.Mvc;

namespace Backend.Web
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
