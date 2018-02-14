using Astra.Facades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Astra.Facades
{
    public interface IBaseFacadeUnitOfWork<TEntity, TSearchContext> : IBaseFacade<TEntity, TSearchContext>
    {
        Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = true,
            CancellationToken cancellationToken = default(CancellationToken));
    }

    public abstract class BaseFacadeUnitOfWork<TEntity, TSearchContext> : IBaseFacadeUnitOfWork<TEntity, TSearchContext>
        where TEntity : BaseEntity
        where TSearchContext : ISearchContext
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _EntitySet;

        protected IRepository<TEntity> EntitySet { get {return _EntitySet;}}

        protected IUnitOfWork UnitOfWork { get {return _unitOfWork;}}

        public BaseFacadeUnitOfWork(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; _EntitySet = _unitOfWork.GetRepository<TEntity>(); }

        public virtual async Task Create(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null)
        {
            if(before != null) before.Invoke(record);
            //record.Active = true;
            if (record is IEntityHistory)
            {
                var auditRec = record as IEntityHistory;
                auditRec.CreatedOn = DateTime.UtcNow;
                auditRec.ModifiedOn = DateTime.Parse("2000-01-01");
            }
            EntitySet.Insert(record);
            await UnitOfWork.SaveChangesAsync();
            if(after != null) after.Invoke(record);

        }

        public virtual async Task Remove(TEntity record, Action<TEntity> before = null, Action<TEntity> after = null)
        {
            if(before != null) before.Invoke(record);
            if (record is IEntitySoftDelete)
            {
                var softDelRec = record as IEntitySoftDelete;
                softDelRec.DeletedOn = DateTime.UtcNow;
                softDelRec.IsDeleted = true;
                EntitySet.Update(record);
            }
            else
                EntitySet.Delete(record);

            await UnitOfWork.SaveChangesAsync();

            if(after!= null) after.Invoke(record);
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
            ignoreProps.AddRange(typeof(IEntityHistory).GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(o => o.Name));
            ignoreProps.AddRange(typeof(IEntitySoftDelete).GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(o => o.Name));

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
                throw new ArgumentException(string.Format("invalid id({0}) of {1}", key.ToString(), typeof(TEntity).Name));

            var data = before(record);
            MapProp(data, record);

            /// TODO: 
            if (record is IEntityHistory)
            {
                var auditRec = record as IEntityHistory;
                auditRec.ModifiedOn = DateTime.UtcNow;
            }
            EntitySet.Update(record);
            await UnitOfWork.SaveChangesAsync();

            if(after!= null) after.Invoke(record);
        }

        public virtual async Task<IEnumerable<TEntity>> Search(TSearchContext search)
        {
            return await Task.FromResult(SearchQuery(search).AsEnumerable());
        }

        public Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Expression<Func<TEntity, object>> include = null,
            int pageIndex = 0,
            int pageSize = 20,
            bool disableTracking = true,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return EntitySet.GetPagedListAsync(predicate, orderBy, include, pageIndex, pageSize, disableTracking, cancellationToken);
        }

        public abstract IQueryable<TEntity> SearchQuery(TSearchContext search);

        public virtual TEntity Find(object key) { return EntitySet.Find(key); }



        public IQueryable<TEntity> Queryable
        {
            get { return EntitySet.Queryable; }
        }
    }
}
