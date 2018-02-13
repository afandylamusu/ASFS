using MasterData.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using MasterData.BusinessFacade;
using System.Linq.Expressions;
using System.Web.Http.OData;
using System.Threading.Tasks;
using System.Web.Http.OData.Query;

namespace MasterData.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/menus")]
    public class MenusController : RestController<MenuItem, MenuSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MenusController(IUnitOfWork context)
            : base(context)
        {
            
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityToUpdate"></param>
        /// <returns></returns>
        protected override MenuItem BeforeUpdate(MenuItem entity, MenuItem entityToUpdate)
        {
            return entityToUpdate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        protected override Expression<Func<MenuItem, bool>> Search(MenuSearchContext filter)
        {
            return x => true;
        }
    }
}