using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;

namespace SchoolProject.Infrastructure.Repositories;


public class GenericRepository<T>(ApplicationDbContext db) : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _db = db;

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetTableNoTracking()
    {
        return _db.Set<T>().AsNoTracking().AsQueryable();
    }

    public virtual async Task AddRangeAsync(ICollection<T> entities)
    {
        await _db.Set<T>().AddRangeAsync(entities);
        await _db.SaveChangesAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
        await _db.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _db.Set<T>().Update(entity);
        await _db.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync();
    }

    public virtual async Task DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }
        await _db.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
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

    public virtual async Task UpdateRangeAsync(ICollection<T> entities)
    {
        _db.Set<T>().UpdateRange(entities);
        await _db.SaveChangesAsync();
    }
}