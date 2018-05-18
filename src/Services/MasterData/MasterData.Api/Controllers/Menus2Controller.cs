using Astra.Facades;
using MasterData.Data.Domain;
using System.Web.Http;

namespace MasterData.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/menus2")]
    internal class Menus2Controller : RestController<IMenuService, Menu, MenuSearchContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public Menus2Controller(IMenuService service) : base(service)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override Menu BeforePut(Menu entity, Menu value)
        {
            return base.BeforePut(entity, value);
        }
    }
}