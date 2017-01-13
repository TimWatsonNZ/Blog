using Blog.Data;
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
        public ActionResult Write(bool update = false)
        {
            var writePostVm = new WritePostVm() { IsUpdate = update };
            return View(writePostVm);
        }
        
        //  To update
        public ActionResult Update(int id)
        {
            return View();
        }

        //  To view
        [AllowAnonymous]
        public ActionResult Index(int id = 1)
        {
            //  Get post from controller.
            var post = _postRepo.GetPost(id);
            var previousPost = _postRepo.GetPrevious(post);
            var nextPost = _postRepo.GetNext(post);

            var blogVm = new BlogPostVm(post, previousPost, nextPost);
            return View(blogVm);
        }
    }
}