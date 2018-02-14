﻿using MasterData.Data.Domain;
using System;
using System.Data.Entity;
using System.Web.Http;
using System.Linq.Expressions;
using Astra.Facades;

namespace MasterData.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/menus")]
    internal class MenusController : RestController<MenuItem, MenuSearchContext>
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