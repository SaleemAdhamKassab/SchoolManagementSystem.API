using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolProject.Infrastructure.Abstracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(ICollection<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(ICollection<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(ICollection<T> entities);
    Task SaveChangesAsync();
    IQueryable<T> GetTableNoTracking();
    IQueryable<T> GetTableAsTracking();
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
}