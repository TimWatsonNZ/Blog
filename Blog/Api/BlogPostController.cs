using Blog.Data;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Blog.Controllers
{
    public class BlogPostController : ApiController
    {
        private IPostRepository _postRepo;

        public BlogPostController(IPostRepository repo)
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


        public BlogPost GetLatest() {
            return _postRepo.GetLatestPost();
        }
    }
}