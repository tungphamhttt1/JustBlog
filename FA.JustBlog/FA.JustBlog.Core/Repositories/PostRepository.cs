using System;
using FA.JustBlog.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FA.JustBlog.Repository.Repositories;

namespace FA.JustBlog.Core.Repositories
{
    public class PostRepository : GenericRepository<DbContext, Post>, IPostRepository
    {


        public PostRepository(DbContext context) : base(context)
        {

        }
        public int CountPostsForCategory(string category)
        {
            return _dbset.Count(p => p.Category.Name.Contains(category));
        }

        public int CountPostsForTag(string tag)
        {
            return _dbset.Count(p => p.Tags.Any(t => t.Name.Contains(tag)));
        }

        public IEnumerable<Post> FindPost(int year, int month, string urlSlug)
        {
            return _dbset.Where(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug.Contains(urlSlug)).ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _dbset.OrderByDescending(p => p.Rate).Take(size).ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return _dbset.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return _dbset.Where(p => p.Category.Name.Contains(category)).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _dbset.Where(p => p.PostedOn.Year == monthYear.Year && p.PostedOn.Month == monthYear.Month).ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return _dbset.Where(p => p.Tags.Any(t => t.Name.Contains(tag))).ToList();
        }

        public IList<Post> GetPublisedPosts()
        {
            return _dbset.Where(p => p.Published == true).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return _dbset.Where(p => p.Published == false).ToList();
        }
        public IEnumerable<Post> GetLatestPosts(int size)
        {
            return _dbset.OrderByDescending(x => x.PostedOn).Take(size);
        }

        public IList<Tag> GetTagsByPost(int id)
        {
            return GetById(id).Tags.ToList();
        }
    }
}
