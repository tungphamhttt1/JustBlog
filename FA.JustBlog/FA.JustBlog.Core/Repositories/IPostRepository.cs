using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;

namespace FA.JustBlog.Repository.Repositories
{
   public interface IPostRepository : IGenericRepository<Post>
    {
        int CountPostsForCategory(string category);
        int CountPostsForTag(string tag);
        IEnumerable<Post> FindPost(int year, int month, string urlSlug);
        IList<Post> GetHighestPosts(int size);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetPostsByCategory(string category);
        IList<Post> GetPostsByTag(string tag);
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IEnumerable<Post> GetLatestPosts(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        IList<Tag> GetTagsByPost(int id);
    }
}
