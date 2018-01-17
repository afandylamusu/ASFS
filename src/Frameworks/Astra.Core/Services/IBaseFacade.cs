using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Core.Services
{
    public interface IBaseFacade<TEntity, TSearchContext>
    {
        Task Update(object key, Func<TEntity, TEntity> before, Action<TEntity> after = null);
        Task Create(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null);
        Task Remove(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null);

        IPagedList<TEntity> PageableSearch(TSearchContext search);
        Task<IEnumerable<TEntity>> Search(TSearchContext search);
        IQueryable<TEntity> SearchQuery(TSearchContext search);
        TEntity Find(object key);
    }
}
