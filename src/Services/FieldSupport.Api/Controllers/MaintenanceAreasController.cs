using Astra.Infrastructure;
using FieldSupport.Api.Services;
using FieldSupport.Domain.Maintenance;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/maintenance")]
    public class MaintenanceAreasController : BaseApiController<IMaintenanceAreaService, MaintenanceArea, MaintenanceAreaSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public MaintenanceAreasController(IMaintenanceAreaService service) : base(service)
        {
        }

        [Route("areas")]
        public override PageResult<MaintenanceArea> Gets(ODataQueryOptions opts, [FromUri] MaintenanceAreaSearchContext search)
        {
            return base.Gets(opts, search);
        }

        [Route("areas")]
        public override Task<IHttpActionResult> Post([FromBody] MaintenanceArea value)
        {
            return base.Post(value);
        }

        [Route("areas/{id:int}")]
        public override Task<IHttpActionResult> Get(int id)
        {
            return base.Get(id);
        }

        [Route("areas/{id:int}")]
        public override Task<IHttpActionResult> Put(int id, [FromBody] MaintenanceArea value)
        {
            return base.Put(id, value);
        }

        [Route("areas/{id:int}")]
        public override Task<IHttpActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [Route("areas/{id:int}")]
        public override Task<IHttpActionResult> Patch(int id, [FromBody] JsonPatchDocument<MaintenanceArea> value)
        {
            return base.Patch(id, value);
        }
    }
}