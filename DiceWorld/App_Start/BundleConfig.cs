using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;
using DiceWorld.Models;

namespace DiceWorld
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.1.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ember").Include(
                      "~/Scripts/handlebars.min.js",
                      "~/Scripts/ember.debug.js",
                      "~/Scripts/ember-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/emberApp").Include(
                    "~/Scripts/Application/application.js",
                    "~/Scripts/Controllers/*.js",
                    "~/Scripts/Models/*.js",
                    "~/Scripts/Routes/*.js"/*,
                    "~/Scripts/Views/*.js",
                    "~/Scripts/Components/*.js"*/));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
