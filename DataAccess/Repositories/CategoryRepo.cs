using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCPractice.DataAccess.Data;
using MVCPractice.Models;

namespace DataAccess.Repositories
{
    public class CategoryRepo : Repo<Category>
    {
        private readonly ProgramContext _context;

        public CategoryRepo(ProgramContext context) : base(context)
        {
            _context = context;
        }

        public override async Task Update(Category entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity is null");
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task UpdateById(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}