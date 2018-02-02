using Astra.Core.Interfaces;
using Astra.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Astra.Infrastructure.Data
{
    public abstract class BaseFacade<TEntity, TSearchContext> : IBaseFacade<TEntity, TSearchContext>
        where TEntity : BaseEntity
    where TSearchContext : ISearchContext
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> entitySet;

        protected DbSet<TEntity> EntitySet => entitySet;

        public IQueryable<TEntity> Queryable => EntitySet.AsQueryable();

        public BaseFacade(DbContext context) {
            _context = context;
            entitySet = _context.Set<TEntity>();
        }

        public virtual async Task Create(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null)
        {
            before?.Invoke(record);
            record.Active = true;
            if (record is IAuditTrail)
            {
                var auditRec = record as IAuditTrail;
                auditRec._CreatedUtc = DateTime.UtcNow;
                auditRec._LastModifiedUtc = DateTime.Parse("2000-01-01");
            }
            EntitySet.Add(record);
            await _context.SaveChangesAsync();
            after?.Invoke(record);

        }

        public virtual async Task Remove(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null)
        {
            before?.Invoke(record);
            if (record is ISoftDelete)
            {
                var softDelRec = record as ISoftDelete;
                softDelRec._DeletedUtc = DateTime.UtcNow;
                softDelRec._IsDeleted = true;
                //EntitySet.UpdateAsync(record);
            }
            else
                EntitySet.Remove(record);

            await _context.SaveChangesAsync();
            after?.Invoke(record);
        }

        /// <summary>
        /// map properties
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <param name="targetObj"></param>
        protected void MapProp(object sourceObj, object targetObj, List<string> ignoreProps = null)
        {
            Type T1 = sourceObj.GetType();
            Type T2 = targetObj.GetType();

            if (ignoreProps == null)
                ignoreProps = new List<string>();

            ignoreProps.Add("Id");
            ignoreProps.AddRange(typeof(IAuditTrail).GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(o => o.Name));
            ignoreProps.AddRange(typeof(ISoftDelete).GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(o => o.Name));

            PropertyInfo[] sourceProprties = T1.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] targetProprties = T2.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var sourceProp in sourceProprties)
            {
                if (ignoreProps.Contains(sourceProp.Name))
                {
                    continue;
                }

                object osourceVal = sourceProp.GetValue(sourceObj, null);
                int entIndex = Array.IndexOf(targetProprties, sourceProp);
                if (entIndex >= 0)
                {
                    var targetProp = targetProprties[entIndex];
                    targetProp.SetValue(targetObj, osourceVal);
                }
            }
        }

        public virtual async Task Update(object key, Func<TEntity, TEntity> before, Action<TEntity> after = null)
        {
            if (before == null)
                throw new ArgumentNullException("before");

            var record = Find(key);
            if (record == null)
                throw new ArgumentException($"invalid id({key.ToString()}) of {nameof(TEntity)}");

            var data = before?.Invoke(record);
            MapProp(data, record);

            /// TODO: 
            if (record is IAuditTrail)
            {
                var auditRec = record as IAuditTrail;
                auditRec._LastModifiedUtc = DateTime.UtcNow;
            }
            
            await _context.SaveChangesAsync();
            after?.Invoke(record);
        }

        public virtual async Task<IEnumerable<TEntity>> Search(TSearchContext search)
        {
            return await Task.FromResult(SearchQuery(search).ToList());
        }

        public virtual IPagedList<TEntity> PageableSearch(TSearchContext search)
        {
            return new PagedList<TEntity>(SearchQuery(search), search.Skip ?? 0, search.Top ?? 25);
        }

        public abstract IQueryable<TEntity> SearchQuery(TSearchContext search);

        public virtual TEntity Find(object key) => EntitySet.Find(key);

    }
}