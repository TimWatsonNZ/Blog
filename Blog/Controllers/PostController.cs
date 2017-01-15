using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        IBlogPostRepository _postRepo;
        public PostController(IBlogPostRepository postRepository)
        {
            _postRepo = postRepository;
        }

        // GET: CreatePost
        [HttpGet]
        public ActionResult Write(int id = -1, bool update = false)
        {
            BlogPost post = null;
            if(id > 0)
            {
                post = _postRepo.GetPost(id);
            }

            var writePostVm = new WritePostVm() {
                IsUpdate = update,
                BlogPost = post != null ? new BlogPostVm(post) : null
            };

            return View(writePostVm);
        }

        //  To view
        [AllowAnonymous]
        public ActionResult Index(int id = 1)
        {
            //  Get post from controller.
            var blogVm = GetPost(id);
            return View(blogVm);
        }

        private BlogPostVm GetPost(int id)
        {
            var post = _postRepo.GetPost(id);
            var previousPost = _postRepo.GetPrevious(post);
            var nextPost = _postRepo.GetNext(post);

            var blogVm = new BlogPostVm(post, previousPost, nextPost);

            return blogVm;
        }
    }
}