using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class NewPostController : Controller
    {
        // GET: CreatePost
        public ActionResult Index()
        {
            return View();
        }
    }
}