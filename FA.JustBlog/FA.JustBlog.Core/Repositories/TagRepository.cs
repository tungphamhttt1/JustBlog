using FA.JustBlog.Core.Models;
using System.Data.Entity;
namespace FA.JustBlog.Core.Repositories
{
    public class TagRepository : GenericRepository<DbContext, Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
        }

        //public IEnumerable<Tag> PopularTags()
        //{
            

        //    return result.ToList();
        //}
    }
}
