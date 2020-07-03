
using Fa.JustBlog.Service.EntityService;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.UnitOfWork;
using FA.JustBlog.Repository.Repositories;
using System;
using System.Collections.Generic;

namespace FA.JustBlog.Service.Services
{
    public class PostService : EntityService<Post>, IPostService
    {
        IPostRepository _postRepository;
        public PostService(IUnitOfWork unitOfWork, IPostRepository postrepository) : base(unitOfWork, postrepository)
        {
            _postRepository = postrepository;
        }

        public int CountPostsForCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new NullReferenceException();
            }
            return _postRepository.CountPostsForCategory(category);
        }

        public int CountPostsForTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new NullReferenceException();
            }
            return _postRepository.CountPostsForTag(tag);
        }

        public IEnumerable<Post> FindPost(int year, int month, string urlSlug)
        {
            return _postRepository.FindPost(year, month, urlSlug);
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _postRepository.GetHighestPosts(size);
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return _postRepository.GetMostViewedPost(size);
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new NullReferenceException();
            }
            return _postRepository.GetPostsByCategory(category);
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _postRepository.GetPostsByMonth(monthYear);
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new NullReferenceException();
            }
            return _postRepository.GetPostsByTag(tag);
        }

        public IList<Post> GetPublisedPosts()
        {
            return _postRepository.GetPublisedPosts();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return _postRepository.GetUnpublisedPosts();
        }
        public IEnumerable<Post> GetLatestPost(int size)
        {
            return _postRepository.GetLatestPosts(size);
        }

        public IList<Tag> GetTagsByPost(int id)
        {
            return _postRepository.GetTagsByPost(id);
        }
    }
}
