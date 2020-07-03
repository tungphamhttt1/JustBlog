using FA.JustBlog.Common;
using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fa.JustBlog.Service.EntityService
{
    public interface IEntityService<T> where T : BaseEntity
    {
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        Task<PaginatedList<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int page = 1, int pageSize = 10);
        void Update(T entity);
        void Delete(int id);
    }
}
