using Astra;
using Astra.Facades;
using MasterData.Data;
using MasterData.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public class MenuSearchContext : SearchContext{

    }

    public interface IMenuService : IBaseFacadeUnitOfWork<MenuItem, MenuSearchContext>
    {

    }

    public class MenuService : BaseFacadeUnitOfWork<MenuItem, MenuSearchContext>, IMenuService
    {
        public MenuService(IUnitOfWork<MasterDataContext> context) : base(context)
        {

        }

        public override IQueryable<MenuItem> SearchQuery(MenuSearchContext search)
        {
            return EntitySet.Queryable.Where(q => true);
        }
    }
}
