using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MVCPractice.Data.Data;

namespace MVCPractice.Data.Repositories;

public abstract class Repo<T> where T : class
{
    private readonly ProgramContext _context;
    private readonly DbSet<T> _dbSet;

    public Repo(ProgramContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public abstract Task UpdateAsync(T entity);
    public abstract Task UpdateAsync(int id);

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(filter);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        return entity;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        return entity;
    }

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        if (entity == null || await _dbSet.FindAsync(entity) == null)
        {
            throw new Exception("Entity not found");
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteRangeAsync(Expression<Func<T, bool>> filter)
    {
        var entities = await _dbSet.Where(filter).ToListAsync();
        _dbSet.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}
