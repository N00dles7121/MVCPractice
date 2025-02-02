using MVCPractice.DataAccess.Data;
using Models;
using Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CategoryRepo : Repo<Category>
    {
        private readonly ProgramContext _context;

        public CategoryRepo(ProgramContext context) : base(context)
        {
            _context = context;
        }

        public async Task ExecuteUpdateAsync(CategoryDTO dto, int id)
        {
            await _context.Categories.Where(m => m.Id == id).ExecuteUpdateAsync(s => s
            .SetProperty(m => m.Name, dto.Name)
            .SetProperty(m => m.DisplayOrder, dto.DisplayOrder));

            await _context.SaveChangesAsync();
        }
    }
}