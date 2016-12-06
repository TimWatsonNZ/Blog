using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [AllowAnonymous]
    public class MainController : Controller
    {
        // GET: Main    -> Just show blog titles as links.
        public ActionResult Index()
        {
            return View();
        }
    }
}