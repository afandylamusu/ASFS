using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public interface IBaseFacade<TEntity, TSearchContext>
    {
        Task Update(object key, Func<TEntity, TEntity> before, Action<TEntity> after = null);
        Task Create(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null);
        Task Remove(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null);

        //IPagedList<TEntity> PageableSearch(TSearchContext search, int pageSize = 25, int pageIndex = 0);
        IQueryable<TEntity> SearchQuery(TSearchContext search);
        TEntity Find(object key);
        IQueryable<TEntity> Queryable { get; }
    }
}
