using Astra;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Extensions;
using System.Web.Http.Results;
using System.Web.Http.ModelBinding;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Net.Http.Formatting;

namespace System.Web.Http
{
    public static class RestControllerExtensions
    {
        public static void Get<TEntity>(this IRestController controller,
            IRepository<TEntity> entitySet,
            Expression<Func<TEntity, bool>> predicate,
            ODataQueryOptions odataOptions,
            out PageResult<TEntity> response)
            where TEntity : BaseEntity
        {
            ODataQuerySettings querySettings = new ODataQuerySettings()
            {
            };

            var validationSettings = new ODataValidationSettings()
            {
                // Initialize settings as needed.
                AllowedFunctions = AllowedFunctions.None,
                AllowedArithmeticOperators = AllowedArithmeticOperators.None,
                AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Skip | AllowedQueryOptions.Top
            };

            odataOptions.Validate(validationSettings);

            var query = entitySet.Queryable.Where(predicate);

            IQueryable results = odataOptions.ApplyTo(query, querySettings);

            response = new PageResult<TEntity>(
                results as IEnumerable<TEntity>,
                controller.Request.ODataProperties().NextLink,
                query.Count());
        }

        public static void Get<TEntity>(this IRestController controller,
           IRepository<TEntity> entitySet,
           Expression<Func<TEntity, bool>> predicate,
           int pageIndex,
           int pageSize,
           out IPagedList<TEntity> response)
           where TEntity : BaseEntity
        {
            response = entitySet.GetPagedList(predicate: predicate, pageIndex: pageIndex, pageSize: pageSize);
        }

        public static void Get<TEntity>(this IRestController controller, IRepository<TEntity> entitySet, Expression<Func<TEntity, bool>> predicate, int id, out IHttpActionResult response)
              where TEntity : BaseEntity
        {
            if (id <= 0)
            {
                response = controller.BadRequest();
                return;
            }

            predicate.AndAlso(x => x.Id == id);
         
            var item = entitySet.GetFirstOrDefault(s => s, predicate);

            if (item != null)
            {
                response = controller.Ok(item);
                return;
            }

            response = controller.NotFound();
        }

        public static void Post<TEntity>(this IRestController controller, IUnitOfWork context, IRepository<TEntity> entitySet, TEntity value, Action<TEntity> before, Action<TEntity> after, string action, out IHttpActionResult response, object routesValue = null)
             where TEntity : BaseEntity
        {
            if (!controller.ModelState.IsValid)
            {
                response = controller.BadRequest(controller.ModelState);
                return;
            }

            value.Active = true;

            before(value);

            if (value is IAuditTrail)
            {
                var auditRecord = value as IAuditTrail;
                auditRecord._CreatedUtc = DateTime.UtcNow;
                auditRecord._CreatedBy = "Test";
                auditRecord._CreatedAgent = "Chrome";
            }

            entitySet.Insert(value);

            context.SaveChanges(value is IAuditTrail);

            after(value);

            response = controller.Created<TEntity>(action, value);
        }

        public static void Put<TEntity>(this IRestController controller, IUnitOfWork context, IRepository<TEntity> entitySet, int id, TEntity value, Func<TEntity, TEntity, TEntity> before, Action<TEntity> after, string action, out IHttpActionResult response, object routesValue = null)
             where TEntity : BaseEntity
        {
            var entity = entitySet
                .Find(id);

            if (entity == null)
            {
                response = controller.NotFound();
                return;
            }

            if (!controller.ModelState.IsValid)
            {
                response = controller.BadRequest(controller.ModelState);
                return;
            }

            // Update current product
            entity = before(entity, value);

            if (entity is IAuditTrail)
            {
                var auditRecord = value as IAuditTrail;
                auditRecord._LastModifiedUtc = DateTime.UtcNow;
                auditRecord._LastModifiedBy = "Test";
                auditRecord._LastModifiedAgent = "Chrome";
            }

            entitySet.Update(entity);

            context.SaveChanges(value is IAuditTrail);

            after(entity);

            response = controller.Created(action, entity);
        }

        public static void Delete<TEntity>(this IRestController controller, IUnitOfWork context, IRepository<TEntity> entitySet, int id, Action<TEntity> before, Action<TEntity> after, out IHttpActionResult response)
             where TEntity : BaseEntity
        {
            var entity = entitySet
                .GetFirstOrDefault(s => s, i => i.Id == id);

            if (entity == null)
            {
                response = controller.NotFound();
                return;
            }

            before(entity);

            entitySet.Delete(entity);

            context.SaveChanges(entity is IAuditTrail);

            after(entity);

            response = controller.Ok();
        }
    }

    public interface IRestController
    {

        //
        // Summary:
        //     Gets the model state after the model binding process.
        //
        // Returns:
        //     The model state after the model binding process.
        ModelStateDictionary ModelState { get; }
        //
        // Summary:
        //     Gets or sets the HttpRequestMessage of the current System.Web.Http.ApiController.
        //
        // Returns:
        //     The HttpRequestMessage of the current System.Web.Http.ApiController.
        HttpRequestMessage Request { get; set; }
        //
        // Summary:
        //     Gets the request context.
        //
        // Returns:
        //     The request context.
        HttpRequestContext RequestContext { get; set; }

        //
        // Summary:
        //     Creates a System.Web.Http.Results.NotFoundResult.
        //
        // Returns:
        //     A System.Web.Http.Results.NotFoundResult.
        NotFoundResult NotFound();
        //
        // Summary:
        //     Creates an System.Web.Http.Results.OkResult (200 OK).
        //
        // Returns:
        //     An System.Web.Http.Results.OkResult.
        OkResult Ok();
        //
        // Summary:
        //     Creates an System.Web.Http.Results.OkNegotiatedContentResult<T> with the
        //     specified values.
        //
        // Parameters:
        //   content:
        //     The content value to negotiate and format in the entity body.
        //
        // Type parameters:
        //   T:
        //     The type of content in the entity body.
        //
        // Returns:
        //     An System.Web.Http.Results.OkNegotiatedContentResult<T> with the specified
        //     values.
        OkNegotiatedContentResult<T> Ok<T>(T content);

        // Summary:
        //     Creates a System.Web.Http.Results.BadRequestResult.
        //
        // Returns:
        //     A System.Web.Http.Results.BadRequestResult.
        BadRequestResult BadRequest();

        //
        // Summary:
        //     Creates an System.Web.Http.Results.InvalidModelStateResult with the specified
        //     model state.
        //
        // Parameters:
        //   modelState:
        //     The model state to include in the error.
        //
        // Returns:
        //     An System.Web.Http.Results.InvalidModelStateResult with the specified model
        //     state.
        InvalidModelStateResult BadRequest(ModelStateDictionary modelState);
        //
        // Summary:
        //     Creates an System.Web.Http.Results.ErrorMessageResult (400 Bad Request) with
        //     the specified error message.
        //
        // Parameters:
        //   message:
        //     The user-visible error message.
        //
        // Returns:
        //     An System.Web.Http.Results.InvalidModelStateResult with the specified model
        //     state.
        BadRequestErrorMessageResult BadRequest(string message);

        //
        // Summary:
        //     Creates a <see cref="T:System.Web.Http.FormattedContentResult`1" /> with
        //     the specified values.
        //
        // Parameters:
        //   statusCode:
        //     The HTTP status code for the response message.
        //
        //   value:
        //     The content value to format in the entity body.
        //
        //   formatter:
        //     The formatter to use to format the content.
        //
        //   mediaType:
        //     The value for the Content-Type header.
        //
        // Type parameters:
        //   T:
        //     The type of content in the entity body.
        //
        // Returns:
        //     A <see cref="T:System.Web.Http.FormattedContentResult`1" /> with the specified
        //     values.
        FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, string mediaType);
        //
        // Summary:
        //     Creates a System.Web.Http.Results.CreatedNegotiatedContentResult<T> (201
        //     Created) with the specified values.
        //
        // Parameters:
        //   location:
        //     The location at which the content has been created.
        //
        //   content:
        //     The content value to negotiate and format in the entity body.
        //
        // Type parameters:
        //   T:
        //     The type of content in the entity body.
        //
        // Returns:
        //     A System.Web.Http.Results.CreatedNegotiatedContentResult<T> with the specified
        //     values.
        CreatedNegotiatedContentResult<T> Created<T>(string location, T content);
        //
        // Summary:
        //     Creates a System.Web.Http.Results.CreatedNegotiatedContentResult<T> (201
        //     Created) with the specified values.
        //
        // Parameters:
        //   location:
        //     The location at which the content has been created.
        //
        //   content:
        //     The content value to negotiate and format in the entity body.
        //
        // Type parameters:
        //   T:
        //     The type of content in the entity body.
        //
        // Returns:
        //     A System.Web.Http.Results.CreatedNegotiatedContentResult<T> with the specified
        //     values.
        CreatedNegotiatedContentResult<T> Created<T>(Uri location, T content);
        //
        // Summary:
        //     Creates a System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<T>
        //     (201 Created) with the specified values.
        //
        // Parameters:
        //   routeName:
        //     The name of the route to use for generating the URL.
        //
        //   routeValues:
        //     The route data to use for generating the URL.
        //
        //   content:
        //     The content value to negotiate and format in the entity body.
        //
        // Type parameters:
        //   T:
        //     The type of content in the entity body.
        //
        // Returns:
        //     A System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<T> with the
        //     specified values.
        CreatedAtRouteNegotiatedContentResult<T> CreatedAtRoute<T>(string routeName, IDictionary<string, object> routeValues, T content);
        //
        // Summary:
        //     Creates a System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<T>
        //     (201 Created) with the specified values.
        //
        // Parameters:
        //   routeName:
        //     The name of the route to use for generating the URL.
        //
        //   routeValues:
        //     The route data to use for generating the URL.
        //
        //   content:
        //     The content value to negotiate and format in the entity body.
        //
        // Type parameters:
        //   T:
        //     The type of content in the entity body.
        //
        // Returns:
        //     A System.Web.Http.Results.CreatedAtRouteNegotiatedContentResult<T> with the
        //     specified values.
        CreatedAtRouteNegotiatedContentResult<T> CreatedAtRoute<T>(string routeName, object routeValues, T content);
    }

    [RoutePrefix("api/bases")]
    public abstract class RestController<TEntity, TSearchContext> : ApiController, IRestController
        where TEntity : BaseEntity
        where TSearchContext : ISearchContext
    {
        private readonly IUnitOfWork _context;
        private readonly IRepository<TEntity> _EntitySet;

        public RestController(IUnitOfWork context)
        {
            _context = context;
            _EntitySet = Context.GetRepository<TEntity>();
        }

        protected IUnitOfWork Context { get {return _context; }}
        protected IRepository<TEntity> EntitySet {get{return _EntitySet; }}

        [Route("")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK)]
        public virtual async Task<PageResult<TEntity>> Get([FromUri]TSearchContext filter, ODataQueryOptions options)
        {
            PageResult<TEntity> response;
            this.Get(EntitySet, Search(filter), options, out response);
            return await Task.FromResult(response);
        }

        //[Route("~/paging")]
        //[HttpGet]
        //[SwaggerResponse(HttpStatusCode.OK)]
        //public virtual async Task<IHttpActionResult> GetPaging([FromUri]TSearchContext filter)
        //{
        //    IPagedList<TEntity> pageList;
        //    this.Get(EntitySet, Search(filter), filter.Skip.Value, filter.Top.Value, out pageList);

        //    return await Task.FromResult(Ok(pageList));
        //}

        protected abstract Expression<Func<TEntity, bool>> Search(TSearchContext filter);

        // GET api/entries/5
        [Route("{id:int}")]
        [HttpGet]
        public virtual async Task<IHttpActionResult> Get(int id)
        {
            IHttpActionResult response;
            this.Get(EntitySet, f => true, id, out response);
            return await Task.FromResult(response);
        }

        // POST api/entries
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Created)]
        public virtual async Task<IHttpActionResult> Post([FromBody]TEntity value)
        {
            IHttpActionResult response;
            this.Post(Context, EntitySet, value, BeforeCreate, AfterCreate, "Get/" + value.Id, out response);
            return await Task.FromResult(response);

        }

        // PUT api/entities/5
        [Route("{id:int}")]
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Accepted)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public virtual async Task<IHttpActionResult> Put(int id, [FromBody]TEntity value)
        {
            IHttpActionResult response;
            this.Put(Context, EntitySet, id, value, BeforeUpdate, AfterUpdate, "Get/" + value.Id, out response);
            return await Task.FromResult(response);

        }

        // DELETE api/values/5
        [Route("{id:int}")]
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.OK)]
        public virtual async Task<IHttpActionResult> Delete(int id)
        {
            IHttpActionResult response;
            this.Delete(Context, EntitySet, id, BeforeDelete, AfterDelete, out response);
            return await Task.FromResult(response);
        }

        #region Callback
        protected virtual void AfterDelete(TEntity entity)
        {

        }

        protected virtual void BeforeDelete(TEntity entity)
        {

        }

        protected virtual void AfterUpdate(TEntity entity)
        {

        }

        protected abstract TEntity BeforeUpdate(TEntity entity, TEntity entityToUpdate);

        protected virtual void BeforeCreate(TEntity value)
        {

        }

        protected virtual void AfterCreate(TEntity value)
        {

        }
        #endregion

        [NonAction]
        public new NotFoundResult NotFound()
        {
            return base.NotFound();
        }

        [NonAction]
        public new OkResult Ok()
        {
            return base.Ok();
        }

        [NonAction]
        public new OkNegotiatedContentResult<T> Ok<T>(T content)
        {
            return base.Ok<T>(content);
        }

        [NonAction]
        public new BadRequestResult BadRequest()
        {
            return base.BadRequest();
        }

        [NonAction]
        public new InvalidModelStateResult BadRequest(ModelStateDictionary modelState)
        {
            return base.BadRequest(modelState);
        }


        [NonAction]
        public new FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, string mediaType)
        {
            return base.Content<T>(statusCode, value, formatter, mediaType);
        }

        [NonAction]
        public new CreatedNegotiatedContentResult<T> Created<T>(string location, T content)
        {
            return base.Created<T>(location, content);
        }

        [NonAction]
        public new CreatedAtRouteNegotiatedContentResult<T> CreatedAtRoute<T>(string routeName, IDictionary<string, object> routeValues, T content)
        {
            return base.CreatedAtRoute<T>(routeName, routeValues, content);
        }

        [NonAction]
        public new CreatedAtRouteNegotiatedContentResult<T> CreatedAtRoute<T>(string routeName, object routeValues, T content)
        {
            return base.CreatedAtRoute(routeName, routeValues, content);
        }

        [NonAction]
        public new BadRequestErrorMessageResult BadRequest(string message)
        {
            return base.BadRequest(message);
        }

        [NonAction]
        public new CreatedNegotiatedContentResult<T> Created<T>(Uri location, T content)
        {
            return base.Created<T>(location, content);
        }
    }
}