
using Fa.JustBlog.Service.EntityService;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;

namespace FA.JustBlog.Service.Services
{
    public interface IPostService : IEntityService<Post>
    {
        int CountPostsForCategory(string category);
        int CountPostsForTag(string tag);
        IEnumerable<Post> FindPost(int year, int month, string urlSlug);
        IList<Post> GetHighestPosts(int size);
        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetPostsByCategory(string category);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        IList<Post> GetPostsByTag(string tag);
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IEnumerable<Post> GetLatestPost(int size);
        IList<Tag> GetTagsByPost(int id);
    }
}
