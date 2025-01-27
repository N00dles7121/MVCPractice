using MVCPractice.DataAccess.Data;
using Models;

namespace DataAccess.Repositories
{
    public class CategoryRepo : Repo<Category>
    {
        private readonly ProgramContext _context;

        public CategoryRepo(ProgramContext context) : base(context)
        {
            _context = context;
        }
    }
}