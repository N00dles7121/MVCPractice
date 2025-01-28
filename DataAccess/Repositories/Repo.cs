using Microsoft.EntityFrameworkCore;
using MVCPractice.DataAccess.Data;

namespace DataAccess.Repositories
{
    public abstract class Repo<T> where T : class
    {
        private readonly ProgramContext _context;
        private readonly DbSet<T> _dbSet;

        public Repo(ProgramContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            return entity;
        }

        public virtual async Task Add(T entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity is null");
            }

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity is null");
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateById(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity is null");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}