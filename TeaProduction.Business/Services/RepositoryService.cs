using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeaProduction.Business.Interfaces;
using TeaProduction.Infrastructure.Data;

namespace TeaProduction.Business.Services
{
    public class RepositoryService<T> : IRepositoryInterface<T> where T : class
    {
        private readonly TeaProductionDbContext teaProductionDbContext;

        public RepositoryService(TeaProductionDbContext teaProductionDbContext)
        {
            this.teaProductionDbContext = teaProductionDbContext;
        }

        public DbSet<T> EntitySet { get => teaProductionDbContext.Set<T>(); }

        public T Add(T entity)
        {
            teaProductionDbContext.Set<T>().Add(entity);
            teaProductionDbContext.SaveChanges();
            return entity;
        }
        public async Task<T> AddAsync(T entity)
        {
            await teaProductionDbContext.Set<T>().AddAsync(entity);
            await teaProductionDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await teaProductionDbContext.Set<T>().AddRangeAsync(entities);
            await teaProductionDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            teaProductionDbContext.Entry(entity).State = EntityState.Modified;
            await teaProductionDbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            teaProductionDbContext.UpdateRange(entities);
            await teaProductionDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {

            teaProductionDbContext.Set<T>().Remove(entity);
            await teaProductionDbContext.SaveChangesAsync();

        }

        public void Delete(T entity)
        {
            teaProductionDbContext.Set<T>().Remove(entity);
            teaProductionDbContext.SaveChanges();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            teaProductionDbContext.Set<T>().RemoveRange(entities);
            await teaProductionDbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return GetAll(disableTracking: true);
        }

        public IQueryable<T> GetAll(bool disableTracking = true)
        {
            IQueryable<T> query = teaProductionDbContext.Set<T>();

            if (disableTracking)
            {
                query.AsNoTracking();
            }
            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool disableTracking = true)
        {
            var query = GetAll(disableTracking: disableTracking);
            if (predicate != null)
                query = query.Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> includeQuery, bool disableTracking = true)
        {
            var query = GetAll(disableTracking: disableTracking);
            query = includeQuery(query);
            return query;
        }

        public IQueryable<T> GetAll(string[] includeTables, bool disableTracking = true)
        {
            var query = GetAll(disableTracking: disableTracking);

            foreach (var table in includeTables)
            {
                query = query.Include(table);
            }

            return query;
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true)
        {
            var query = GetAll(disableTracking: disableTracking);

            foreach (var table in includeTables)
            {
                query = query.Include(table);
            }

            return query.Where(predicate);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> includeQuery, bool disableTracking = true)
        {
            var query = GetAll(disableTracking: disableTracking);
            query = includeQuery(query);
            return query.Where(predicate);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate
            , bool disableTracking = true
            , params string[] includingFieldNames) =>
            GetAll(predicate, includingFieldNames.ToArray(), disableTracking);

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true)
        {
            var query = GetAll(disableTracking: disableTracking);

            query = query.Where(predicate);

            return orderBy(query);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true)
        {
            var query = GetAll(disableTracking: disableTracking);

            query = query.Where(predicate);

            foreach (var table in includeTables)
            {
                query = query.Include(table);
            }

            return orderBy(query);
        }


    }
}
