using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TeaProduction.Business.Interfaces
{
    public interface IRepositoryInterface<T> where T : class
    {
        DbSet<T> EntitySet { get; }
        T Add(T entity);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(bool disableTracking = true);
        IQueryable<T> GetAll(Func<IQueryable<T>, IQueryable<T>> includeQuery, bool disableTracking = true);
        IQueryable<T> GetAll(string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, string[] includeTables, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> includeQuery, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool disableTracking = true, params string[] includingEntityFieldNames);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string[] includeTables, bool disableTracking = true);

    }
}
