using Astra.Infrastructure;
using FieldSupport.Api.Services;
using FieldSupport.Domain.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/menus")]
    public class MenusController : BaseApiController<IMenuService, MenuItem, MenuSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public MenusController(IMenuService service) : base(service)
        {

        }
    }
}