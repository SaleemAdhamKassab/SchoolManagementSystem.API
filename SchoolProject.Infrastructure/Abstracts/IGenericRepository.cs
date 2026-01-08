using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolProject.Infrastructure.Abstracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task DeleteRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    IQueryable<T> GetTableNoTracking();
    IQueryable<T> GetTableAsTracking();
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
}