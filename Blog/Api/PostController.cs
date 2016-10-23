using Blog.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Blog.Controllers
{
    public class PostController : ApiController
    {
        private IPostRepository _postRepo;

        public PostController(IPostRepository repo)
        {
            _postRepo = repo;
        }

        public IEnumerable<BlogPost> GetPosts()
        {
            return _postRepo.GetPosts();
        }

        public void Post([FromBody]BlogPost post)
        {
            post.Created = DateTime.Now;

            _postRepo.SavePost(post);
        }
    }
}