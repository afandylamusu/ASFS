using Astra.Core.Interfaces;
using Astra.Core.SharedKernel;
using Marvin.JsonPatch;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Extensions;
using System.Net.Http;

namespace Astra.Infrastructure
{
    public abstract class BaseApiController<TService, TEntity, TSearchContext> : ApiController
    where TService : IBaseFacade<TEntity, TSearchContext>
    where TEntity : BaseEntity, new()
    {
        private readonly Lazy<TService> _service;

        static Type EntityType => typeof(TEntity);

        protected Lazy<TService> Service => _service;

        public BaseApiController(TService service)
        {
            _service = new Lazy<TService>(() => service);
        }

        // GET: api/values
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        public virtual PageResult<TEntity> Gets(ODataQueryOptions opts, [FromUri] TSearchContext search)
        {
            ODataQuerySettings querySettings = new ODataQuerySettings()
            {
                PageSize = 100
            };


            var settings = new ODataValidationSettings()
            {
                // Initialize settings as needed.
                AllowedFunctions = AllowedFunctions.None,
                AllowedArithmeticOperators = AllowedArithmeticOperators.None
            };

            opts.Validate(settings);

            var results = opts.ApplyTo(Service.Value.SearchQuery(search), querySettings);

            return new PageResult<TEntity>(
                results as IEnumerable<TEntity>,
                Request.ODataProperties().NextLink,
                Request.ODataProperties().TotalCount);
        }


        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public virtual async Task<IHttpActionResult> Get(int id) {
            var record = Service.Value.Find(id);
            if (record != null)
                return Ok(record);
            else
                return NotFound();
        }


        // POST api/values
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public virtual async Task<IHttpActionResult> Post([FromBody]TEntity value)
        {
            await Service.Value.Create(value, BeforePost, AfterPost);
            return Ok(value);
        }

        [NonAction]
        protected virtual void AfterPost(TEntity value)
        {

        }

        [NonAction]
        protected virtual void BeforePost(TEntity value)
        {

        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public virtual async Task<IHttpActionResult> Put(int id, [FromBody]TEntity value)
        {
            await Service.Value.Update(id, entity => {
                return BeforePut(entity, value);
            }, AfterPut);

            return Ok();
        }

        [NonAction]
        protected virtual TEntity BeforePut(TEntity entity, TEntity value)
        {
            return value;
        }

        [NonAction]
        protected virtual void AfterPut(TEntity newValue)
        {

        }

        [Route("{id}")]
        [HttpPatch]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public virtual async Task<IHttpActionResult> Patch(int id, [FromBody]JsonPatchDocument<TEntity> value)
        {
            await Service.Value.Update(id, entity => {
                return BeforePatch(entity, value);
            }, AfterPatch);

            return Ok();
        }

        [NonAction]
        protected virtual void AfterPatch(TEntity obj)
        {

        }

        [NonAction]
        protected virtual TEntity BeforePatch(TEntity entity, JsonPatchDocument<TEntity> value)
        {
            value.ApplyTo(entity);

            return entity;
        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        public virtual async Task<IHttpActionResult> Delete(int id)
        {
            await Service.Value.Remove(Service.Value.Find(id), BeforeDelete, AfterDelete);
            return Ok();
        }

        [NonAction]
        protected virtual void AfterDelete(TEntity value)
        {

        }

        [NonAction]
        protected virtual void BeforeDelete(TEntity value)
        {

        }
    }

}
