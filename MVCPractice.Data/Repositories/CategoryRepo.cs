using System;
using Microsoft.EntityFrameworkCore;
using MVCPractice.Data.Data;
using MVCPractice.Models;

namespace MVCPractice.Data.Repositories;

public class CategoryRepo : Repo<Category>
{
    private readonly ProgramContext _context;
    private readonly DbSet<Category> _dbSet;
    public CategoryRepo(ProgramContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Category>();
    }

    public override async Task UpdateAsync(Category entity)
    {
        if (entity == null || await _dbSet.FindAsync(entity) == null)
        {
            throw new Exception("Entity not found");
        }

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public override async Task UpdateAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new Exception("Entity not found");
        }

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
