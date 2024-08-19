using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Constant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DBContext _context;

        public GenericRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.SingleOrDefault(criteria);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
        {
            return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void AttachRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AttachRange(entities);
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().CountAsync(criteria);
        }



















        ////////////////////////////////// Add new Functions 
        //DbContext Context;
        //public Repository(DbContext dBContext)
        //{
        //    Context = dBContext;
        //}
        //public TEntity Find(object id)
        //{
        //    return Context.Set<TEntity>().Find(id);
        //}

        //public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();

        //    query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    return filter != null ? query.SingleOrDefault(filter) : query.SingleOrDefault();
        //}
        //public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();

        //    query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    return filter != null ? query.FirstOrDefault(filter) : query.FirstOrDefault();
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return Context.Set<TEntity>().AsEnumerable();
        //}

        //public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();
        //    query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    return query.AsEnumerable();
        //}
        //public bool Any(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return Context.Set<TEntity>().Any(predicate);
        //}
        //public bool Any()
        //{
        //    return Context.Set<TEntity>().Any();
        //}
        //public IQueryable<TEntity> GetQueryable()
        //{
        //    return Context.Set<TEntity>().AsQueryable();
        //}

        //public IEnumerable<TEntity> PageAll(int skip, int take)
        //{
        //    return Context.Set<TEntity>().Skip(skip).Take(take);
        //}
        //public IEnumerable<TEntity> PageAll(int skip, int take, Expression<Func<TEntity, bool>> predicate)
        //{
        //    return Context.Set<TEntity>().Where(predicate).Skip(skip).Take(take);
        //}
        //public IEnumerable<TEntity> PageAll(int skip, int take, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();
        //    query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    return query.Skip(skip).Take(take).AsEnumerable();
        //}
        //public IEnumerable<TEntity> PageAll(int skip, int take, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();

        //    query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    if (filter != null)
        //        query = query.Where(filter);

        //    return query.Skip(skip).Take(take).AsEnumerable();
        //}

        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return Context.Set<TEntity>().Where(predicate);
        //}

        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();

        //    query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    if (filter != null)
        //        query = query.Where(filter);

        //    return query.AsEnumerable();
        //}

        //public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();

        //    query = includes.Aggregate(query, (current, include) => current.Include(include));

        //    if (filter != null)
        //        query = query.Where(filter);

        //    if (orderBy != null)
        //        query = orderBy(query);

        //    return query.AsEnumerable();
        //}

        //public int Max(Func<TEntity, int> selector)
        //{
        //    if (Context.Set<TEntity>().Any())
        //    {
        //        return Context.Set<TEntity>().Max(selector);
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}
        //public long Max(Func<TEntity, long> selector)
        //{
        //    if (Context.Set<TEntity>().Any())
        //    {
        //        return Context.Set<TEntity>().Max(selector);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public IEnumerable<TEntity> Include(Expression<Func<TEntity, object>> predicate)
        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();
        //    return query.Include(predicate);
        //}
        //public IEnumerable<TEntity> IncludeMultiple(Expression<Func<TEntity, bool>> wherePredicate, params Expression<Func<TEntity, object>>[] includeProperties)

        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();
        //    if (includeProperties != null)
        //    {

        //        foreach (var item in includeProperties)
        //        {
        //            query.Include(item);
        //        }

        //        return query;

        //    }

        //    return query;
        //}

        //public IEnumerable<TEntity> IncludeMultiple(params Expression<Func<TEntity, object>>[] includeProperties)

        //{
        //    IQueryable<TEntity> query = Context.Set<TEntity>();
        //    if (includeProperties != null)
        //    {

        //        foreach (var item in includeProperties)
        //        {
        //            query.Include(item);
        //        }

        //        return query;

        //    }

        //    return query;
        //}




        //public int Count()
        //{
        //    return Context.Set<TEntity>().Count();
        //}

        //public int Count(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return Context.Set<TEntity>().Count(predicate);
        //}

        //public TEntity Add(TEntity entity)
        //{
        //    return Context.Set<TEntity>().Add(entity);
        //}

        //public void AddRange(IEnumerable<TEntity> entities)
        //{
        //    Context.Set<TEntity>().AddRange(entities);
        //}


        //public void Remove(object id)
        //{
        //    var entity = Find(id);
        //    if (entity != null)
        //        Context.Set<TEntity>().Remove(entity);
        //}

        //public void Remove(TEntity entity)
        //{
        //    Context.Set<TEntity>().Remove(entity);
        //}
        //public void AddOrUpdate(TEntity entity)
        //{
        //    Context.Set<TEntity>().AddOrUpdate(entity);
        //}
        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    Context.Set<TEntity>().RemoveRange(entities);
        //}
    }
}
