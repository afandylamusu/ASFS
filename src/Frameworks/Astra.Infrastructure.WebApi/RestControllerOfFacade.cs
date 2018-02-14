using Astra.Facades;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;

namespace System.Web.Http
{
    [RoutePrefix("api/bases")]
    public abstract class RestController<TService, TEntity, TSearchContext> : ApiController
        where TService : IBaseFacadeUnitOfWork<TEntity, TSearchContext>
        where TEntity : BaseEntity
    {
        private readonly Lazy<TService> _service;

        protected Lazy<TService> Service { get { return _service; } }

        public RestController(TService service)
        {
            _service = new Lazy<TService>(() => service);
        }

        [Route("")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        public virtual async Task<PageResult<TEntity>> Get([FromUri]TSearchContext filter, ODataQueryOptions options)
        {
            PageResult<TEntity> response;

            var validationSettings = new ODataValidationSettings()
            {
                // Initialize settings as needed.
                AllowedFunctions = AllowedFunctions.None,
                AllowedArithmeticOperators = AllowedArithmeticOperators.None,
                AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Skip | AllowedQueryOptions.Top
            };

            options.Validate(validationSettings);

            var query = Service.Value.SearchQuery(filter);

            IQueryable results = options.ApplyTo(query);

            response = new PageResult<TEntity>(
                results as IEnumerable<TEntity>,
                this.Request.ODataProperties().NextLink,
                query.Count());

            return await Task.FromResult(response);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]TEntity value)
        {
            await Service.Value.Create(value, BeforePost, AfterPost);
        }

        // GET api/values/5
        [Route("{id}")]
        [HttpGet]
        public virtual TEntity Get(int id) { return Service.Value.Find(id); }


        // PUT api/values/5
        [Route("{id}")]
        [HttpPut]
        public virtual async Task Put(int id, [FromBody]TEntity value)
        {
            await Service.Value.Update(id, entity =>
            {
                return BeforePut(entity, value);
            }, AfterPut);
        }

        // DELETE api/values/5
        [HttpDelete]
        public virtual async Task Delete(int id)
        {
            await Service.Value.Remove(Service.Value.Find(id), BeforeDelete, AfterDelete);
        }

        #region Callback
        protected virtual void AfterPost(TEntity value)
        {
        }

        protected virtual void BeforePost(TEntity value)
        {
        }

        protected virtual TEntity BeforePut(TEntity entity, TEntity value)
        {
            return value;
        }

        protected virtual void AfterPut(TEntity newValue)
        {

        }

        protected virtual void AfterDelete(TEntity value)
        {

        }

        protected virtual void BeforeDelete(TEntity value)
        {

        } 
        #endregion
    }

}
