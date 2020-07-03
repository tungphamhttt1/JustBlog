using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get all object of a table
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get Object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// Add ac object to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Add(TEntity entity);

        /// <summary>
        /// Update a object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(TEntity entity);

        /// <summary>
        /// Delete a object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(int id);

        /// <summary>
        /// Delete a object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete(TEntity entity);
        /// <summary>
        /// Get entity
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
    }
}
