using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Blog.Models;
using Owin;
using Blog.Data;
using Microsoft.Owin.Security.Cookies;
using System.Configuration;
using System;

namespace Blog
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class IdentityConfig
    {
        public static string UserEmail { get; private set; } = Guid.NewGuid().ToString();
        public static string UserPassword { get; private set; } = Guid.NewGuid().ToString();

        public void Configuration(IAppBuilder app) 
        {
            app.CreatePerOwinContext(() => new DbContext());
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(new RoleStore<AppRole>(context.Get<DbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            var appSettings = ConfigurationManager.AppSettings;

            UserEmail = appSettings["UserEmail"].ToString();
            UserPassword = appSettings["UserPassword"].ToString();
        }
    }
}
