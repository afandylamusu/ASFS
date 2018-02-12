using Astra.Infrastructure;
using FieldSupport.Api.Services;
using FieldSupport.Domain.Maintenance;
using Marvin.JsonPatch;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/departments")]
    public class MaintenanceGroupsController : BaseApiController<IMaintenanceGroupService, MaintenanceGroup, MaintenanceGroupSearchContext>
    {
        public MaintenanceGroupsController(IMaintenanceGroupService service) : base(service)
        {
        }

        #region Obsolates
        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override PageResult<MaintenanceGroup> Gets(ODataQueryOptions opts, [FromUri] MaintenanceGroupSearchContext search)
        {
            throw new NotSupportedException();
        }

        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Task<IHttpActionResult> Get(int id)
        {
            throw new NotSupportedException();
        }

        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Task<IHttpActionResult> Post([FromBody] MaintenanceGroup value)
        {
            throw new NotSupportedException();
        }

        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Task<IHttpActionResult> Delete(int id)
        {
            throw new NotSupportedException();
        }

        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Task<IHttpActionResult> Put(int id, [FromBody] MaintenanceGroup value)
        {
            throw new NotSupportedException();
        }

        [Obsolete]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Task<IHttpActionResult> Patch(int id, [FromBody]JsonPatchDocument<MaintenanceGroup> value)
        {
            throw new NotSupportedException();
        }

        #endregion

        [Route("{id}/groups")]
        public PageResult<MaintenanceGroup> Gets(int id, ODataQueryOptions opts, [FromUri] MaintenanceGroupSearchContext search)
        {
            return base.Gets(opts, search);
        }

        [Route("{id}/groups")]
        public Task<IHttpActionResult> Post(int id, [FromBody] MaintenanceGroup value)
        {
            return base.Post(value);
        }

        [Route("{dept}/groups/{id}")]

        public Task<IHttpActionResult> Get(int dept, int id)
        {
            return base.Get(id);
        }

        [Route("{dept}/groups/{id}")]
        public Task<IHttpActionResult> Put(int dept, int id, [FromBody] MaintenanceGroup value)
        {
            return base.Put(id, value);
        }

        [Route("{dept}/groups/{id}")]
        public Task<IHttpActionResult> Delete(int dept, int id)
        {
            return base.Delete(id);
        }

    }
}