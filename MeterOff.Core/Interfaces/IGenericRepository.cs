using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);
        void AttachRange(IEnumerable<T> entities);
        int Count();
        int Count(Expression<Func<T, bool>> criteria);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> criteria);














        ////////////////////////////TEntity Find(object id);

        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        //TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        //IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        //IQueryable<TEntity> GetQueryable();
        //IEnumerable<TEntity> PageAll(int skip, int take);
        //IEnumerable<TEntity> PageAll(int skip, int take, Expression<Func<TEntity, bool>> predicate);
        //IEnumerable<TEntity> PageAll(int skip, int take, params Expression<Func<TEntity, object>>[] includes);
        //IEnumerable<TEntity> PageAll(int skip, int take, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        //IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        //IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

        //IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        //int Max(Func<TEntity, int> selector);

        //IEnumerable<TEntity> Include(Expression<Func<TEntity, object>> predicate);
        //IEnumerable<TEntity> IncludeMultiple(Expression<Func<TEntity, bool>> wherePredicate, params Expression<Func<TEntity, object>>[] includeProperties);
        //IEnumerable<TEntity> IncludeMultiple(params Expression<Func<TEntity, object>>[] includeProperties);

        //bool Any(Expression<Func<TEntity, bool>> predicate);
        //bool Any();
        //long Max(Func<TEntity, long> selector);

        //int Count();
        //int Count(Expression<Func<TEntity, bool>> predicate);

        //TEntity Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        //void Remove(object id);
        //void Remove(TEntity entity);
        //void AddOrUpdate(TEntity entity);

        //void RemoveRange(IEnumerable<TEntity> entities);

    }
}
