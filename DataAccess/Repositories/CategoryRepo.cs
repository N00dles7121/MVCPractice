using MVCPractice.DataAccess.Data;
using Models;

namespace DataAccess.Repositories
{
    public class CategoryRepo : Repo<Category>
    {
        public CategoryRepo(ProgramContext context) : base(context)
        {
        }
    }
}