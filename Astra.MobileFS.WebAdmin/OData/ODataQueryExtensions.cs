using Astra.MobileFS.WebAdmin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;

namespace System.Web.Http.OData
{
    /// <summary>
    /// 
    /// </summary>
    public static class ODataQueryExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="options"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        internal static IQueryable<T> ApplyOData<T>(this IQueryable<T> query, ODataQueryOptions options, out long count)
        {
            ODataQuerySettings settings = new ODataQuerySettings()
            {
                PageSize = 25
            };


            var validationSettings = new ODataValidationSettings()
            {
                // Initialize settings as needed.
                AllowedQueryOptions = AllowedQueryOptions.OrderBy | AllowedQueryOptions.Skip | AllowedQueryOptions.Top | AllowedQueryOptions.Filter
            };

            options.Validate(validationSettings);

            count = query.LongCount();

            return options.ApplyTo(query, settings) as IQueryable<T>;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller"></param>
        /// <param name="itemsPage"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        internal static GenericPageResult<T> ToPageResult<T>(this ApiController controller, IEnumerable<T> itemsPage, long count)
        {
            var pageResult = new GenericPageResult<T>(
                 itemsPage,
                 controller.Request.ODataProperties().NextLink,
                 count);

            return pageResult;
        }
    }

}