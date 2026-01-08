using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure.Repositories;


public class GenericRepository<T>(ApplicationDbContext db) : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _db = db;

    public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _db.Set<T>().FindAsync(id,cancellationToken);
    }

    public IQueryable<T> GetTableNoTracking()
    {
        return _db.Set<T>().AsNoTracking().AsQueryable();
    }

    public virtual async Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken)
    {
        await _db.Set<T>().AddRangeAsync(entities,cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _db.Set<T>().AddAsync(entity, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _db.Set<T>().Update(entity);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(T entity,CancellationToken cancellationToken)
    {
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(ICollection<T> entities,CancellationToken cancellationToken)
    {
        foreach (var entity in entities)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _db.Database.BeginTransaction();
    }

    public void Commit()
    {
        _db.Database.CommitTransaction();
    }

    public void RollBack()
    {
        _db.Database.RollbackTransaction();
    }

    public IQueryable<T> GetTableAsTracking()
    {
        return _db.Set<T>().AsQueryable();
    }

    public virtual async Task UpdateRangeAsync(ICollection<T> entities,CancellationToken cancellationToken)
    {
        _db.Set<T>().UpdateRange(entities);
        await _db.SaveChangesAsync(cancellationToken);
    }
}