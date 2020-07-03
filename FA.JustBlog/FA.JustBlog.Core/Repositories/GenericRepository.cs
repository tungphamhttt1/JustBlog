using FA.JustBlog.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class GenericRepository<TContext, T> : IGenericRepository<T> where T : class
        where TContext : DbContext

    {

        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset;
        }

        public virtual T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public virtual void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            //_dbset.AddOrUpdate(entity);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy != null ? orderBy(query) : query;
        }

    }
}
