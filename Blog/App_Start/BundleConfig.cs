﻿using System.Web;
using System.Web.Optimization;

namespace Blog
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/base").Include(
                         "~/Scripts/angular.min.js",
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/app/util.js",
                "~/app/mainApp.js",
                "~/app/services/postService.js",
                "~/app/controllers/mainController.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/post").Include(
                "~/app/util.js",
                "~/app/postApp.js",
                "~/app/services/postService.js",
                "~/app/controllers/postController.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/writePost").Include(
                "~/app/util.js",
                "~/app/postModel.js",
                "~/app/writePostApp.js",
                "~/app/services/postService.js",
                "~/app/controllers/writePostController.js"
            ));
        }
    }
}
