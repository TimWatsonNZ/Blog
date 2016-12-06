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
        // GET: CreatePost
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        //  To update
        public ActionResult Update(int id)
        {
            return View();
        }

        //  To view
        [AllowAnonymous]
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}