using Astra;
using Astra.Facades;
using MasterData.Data;
using MasterData.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterData.BusinessFacade
{
    public class MenuSearchContext : SearchContext{

    }

    public interface IMenuService : IBaseFacade<MenuItem, MenuSearchContext>
    {

    }

    public class MenuFacade : BaseFacade<MenuItem, MenuSearchContext>, IMenuService
    {
        public MenuFacade(MasterDataContext context) : base(context)
        {

        }

        public override IQueryable<MenuItem> SearchQuery(MenuSearchContext search)
        {
            return EntitySet.Where(q => true);
        }
    }
}
