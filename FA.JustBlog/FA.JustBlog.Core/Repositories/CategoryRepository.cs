using FA.JustBlog.Core.Models;
using System.Data.Entity;

namespace FA.JustBlog.Core.Repositories
{
    public class CategoryRepository : GenericRepository<DbContext, Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {

        }
    }
}
