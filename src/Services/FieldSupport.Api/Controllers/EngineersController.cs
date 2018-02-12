using Astra.Infrastructure;
using FieldSupport.Api.Services;
using FieldSupport.Domain.Maintenance;
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
    [RoutePrefix("api/engineers")]
    public class EngineersController : BaseApiController<IEngineerService, Engineer, EngineerSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public EngineersController(IEngineerService service) : base(service)
        {

        }
    }


    
}