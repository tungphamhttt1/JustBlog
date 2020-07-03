using FA.JustBlog.Common;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.UnitOfWork;
using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fa.JustBlog.Service.EntityService
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }
        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Commit();
        }

        public async Task<PaginatedList<T>> GetAsync(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "", int page = 1, int pageSize = 2)
        {
            var query = _repository.Get(filter: filter, includeProperties: includeProperties);
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await PaginatedList<T>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }

    }
}
