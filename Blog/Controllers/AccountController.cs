using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl) 
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model) 
        {
            if(!ModelState.IsValid) 
            {
                return View();
            }
            
            if(model.Email == IdentityConfig.UserEmail && model.Password == IdentityConfig.UserPassword)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "Tim"),
                    new Claim(ClaimTypes.Email, "tim.watson.nz@gmail.com"),
                    new Claim(ClaimTypes.Country, "New Zealand")
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("LoggedOut", "Account");
        }

        public ActionResult LoggedOut()
        {
            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if(string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "Main");
            }

            return returnUrl;
        }
    }
}