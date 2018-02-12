using Astra.Core.Interfaces;
using Astra.Infrastructure.Data;
using FieldSupport.Api.Infrastructure;
using FieldSupport.Domain.Setting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FieldSupport.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuSearchContext : SearchContext
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IMenuService : IBaseFacade<MenuItem, MenuSearchContext>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class MenuService : BaseFacade<MenuItem, MenuSearchContext>, IMenuService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public MenuService(FieldSupportContext context) : base(context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override IQueryable<MenuItem> SearchQuery(MenuSearchContext search)
        {
            return EntitySet.Where(q => true);
        }
    }
}