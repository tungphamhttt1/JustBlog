using Fa.JustBlog.Service.EntityService;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.UnitOfWork;

namespace FA.JustBlog.Service.Services
{
    public class CategoryService : EntityService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository):base(unitOfWork, categoryRepository)
        {
        }
    }
}
