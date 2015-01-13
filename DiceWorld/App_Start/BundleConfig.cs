using System.Web;
using System.Web.Optimization;

namespace DiceWorld
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/ember").Include(
                      "~/Scripts/handlebars.js",
                      "~/Scripts/ember.debug.js"));

            bundles.Add(new ScriptBundle("~/bundles/emberApp").Include(
                    "~/Scripts/Application/application.js",
                    "~/Scripts/Controllers/*.js",
                    "~/Scripts/Models/*.js",
                    "~/Scripts/Routes/*.js",
                    "~/Scripts/Components/*.js",
                    "~/Scripts/Views/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
