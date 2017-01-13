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
        public IHttpActionResult Get(string orderBy = "created", int count = 10)
        {
            if (count == 0 || string.IsNullOrWhiteSpace(orderBy))
            {
                return Ok(new List<BlogPostSummary>());
            }
            try
            {
                bool ascending = true;
                if (orderBy[0] == '-')
                {
                    ascending = false;
                }

                var posts = _postRepo.GetPosts(orderBy, count);

                return Ok(posts);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Summaries(string orderBy = "created", int? count = null)
        {
            if (count == 0 || string.IsNullOrWhiteSpace(orderBy))
            {
                return Ok(new List<BlogPostSummary>());
            }
            try
            {
                var posts = _postRepo.GetPosts(orderBy, count);

                return Ok(posts.Select(p => new BlogPostSummary(p)));
            }
            catch(Exception)
            {
                return InternalServerError();
            }
        }

        public int Test()
        {
            return 1;
        }

        public IHttpActionResult Post([FromBody]BlogPost post)
        {
            if(post == null)
            {
                return BadRequest();
            }

            try
            {
                post.Created = DateTime.Now;
                _postRepo.SavePost(post);

                return Ok(post);
            }
            catch(Exception)
            {
                return InternalServerError();
            }
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