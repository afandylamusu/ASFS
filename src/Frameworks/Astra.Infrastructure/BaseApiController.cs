using Astra.Core.Services;
using Astra.Core.SharedKernel;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Astra.Infrastructure
{
    public abstract class BaseApiController<TService, TEntity, TKey, TSearchContext> : ApiController
    where TService : IBaseFacade<TEntity, TSearchContext>
    where TEntity : BaseEntity, new()
    {
        private readonly Lazy<TService> _service;

        protected Lazy<TService> Service => _service;

        public BaseApiController(TService service)
        {
            _service = new Lazy<TService>(() => service);
        }

        // GET: api/values
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]TSearchContext query)
        {
            return Ok(await Service.Value.Search(query));
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(TKey id) => Ok(Service.Value.Find(id));


        // POST api/values
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]TEntity value)
        {
            await Service.Value.Create(value, BeforePost, AfterPost);
            return Ok();
        }

        protected virtual void AfterPost(TEntity value)
        {

        }

        protected virtual void BeforePost(TEntity value)
        {

        }

        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put(TKey id, [FromBody]TEntity value)
        {
            await Service.Value.Update(id, entity => {
                return BeforePut(entity, value);
            }, AfterPut);

            return Ok();
        }

        protected virtual TEntity BeforePut(TEntity entity, TEntity value)
        {
            return value;
        }

        protected virtual void AfterPut(TEntity newValue)
        {

        }

        [Route("{id}")]
        [HttpPatch]
        public async Task<IHttpActionResult> Patch(TKey id, [FromBody]JsonPatchDocument<TEntity> value)
        {
            await Service.Value.Update(id, entity => {
                return BeforePatch(entity, value);
            }, AfterPatch);

            return Ok();
        }

        protected virtual void AfterPatch(TEntity obj)
        {

        }

        protected virtual TEntity BeforePatch(TEntity entity, JsonPatchDocument<TEntity> value)
        {
            value.ApplyTo(entity);

            return entity;
        }

        // DELETE api/values/5
        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(TKey id)
        {
            await Service.Value.Remove(Service.Value.Find(id), BeforeDelete, AfterDelete);
            return Ok();
        }

        protected virtual void AfterDelete(TEntity value)
        {

        }

        protected virtual void BeforeDelete(TEntity value)
        {

        }
    }

}
