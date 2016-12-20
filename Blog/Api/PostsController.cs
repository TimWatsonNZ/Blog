using Blog.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Blog.ViewModels;

namespace Blog.Api
{
    public class PostsController : ApiController
    {
        private IBlogPostRepository _postRepo;

        public PostsController(IBlogPostRepository repo)
        {
            _postRepo = repo;
        }

        [HttpGet]
        public IEnumerable<BlogPost> Get(string orderBy = "created", int count = 10)
        {
            if (count == 0 || string.IsNullOrWhiteSpace(orderBy)) {
                return new List<BlogPost>();
            }

            bool ascending = true;
            if(orderBy[0] == '-')
            {
                ascending = false;
            }

            var posts = _postRepo.GetPosts(orderBy, count);

            return posts;
        }

        [HttpGet]
        public IEnumerable<BlogPostSummary> Summaries(string orderBy = "created", int? count = null)
        {
            if (count == 0 || string.IsNullOrWhiteSpace(orderBy))
            {
                return new List<BlogPostSummary>();
            }
            
            var posts = _postRepo.GetPosts(orderBy, count);

            return posts.Select(p => new BlogPostSummary(p));
        }

        public int Test()
        {
            return 1;
        }

        public int Post([FromBody]BlogPost post)
        {
            post.Created = DateTime.Now;
            return _postRepo.SavePost(post);
        }

        //public bool Put([FromBody]BlogPost post)
        //{
        //    _postRepo.UpdatePost(post);
        //    return true;
        //}

        //public BlogPost GetLatest() 
        //{
        //    return _postRepo.GetLatestPost();
        //}

        //public IEnumerable<BlogPost> GetLatestN(int n) 
        //{
        //    return _postRepo.GetLatestNPosts(n);
        //}

        //public IEnumerable<BlogPost> GetPageOfPosts()
        //{
        //    return _postRepo.GetPageOfPosts();
        //}
    }
}