﻿using System.Web;
using System.Web.Optimization;

namespace MC.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            

                bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                        "~/Scripts/Custom/HomeManager.js",
                         //"~/Content/js/jquery-3.2.1.min.js",
                         //"~/Scripts/jquery-1.10.2.min.js",
                         "~/Content/js/jquery-3.4.1.min.js",
                        "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                      "~/Content/TWFzdGVyQ2hlZg/css/reset.css",
                      "~/Content/TWFzdGVyQ2hlZg/css/materialize.min.css",
                       "~/Content/TWFzdGVyQ2hlZg/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Plugins/bootstrap/css/bootstrap.min.css",
                      "~/Content/css/style.css",
                      "~/Content/css/reset.css"));
        }
    }
}
