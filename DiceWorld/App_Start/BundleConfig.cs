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
                        "~/bower_components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/bower_components/typeahead.js/dist/typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/ember").Include(
                      "~/bower_components/ember/ember-template-compiler.js",
                      "~/bower_components/ember/ember.js",
                      "~/bower_components/ember-data/ember-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/emberApp").Include(
                    //"~/Scripts/Templates/*.js",
                    "~/Scripts/Application/application.js",
                    "~/Scripts/Models/*.js",
                    "~/Scripts/Controllers/*.js",
                    "~/Scripts/Routes/*.js",
                    //"~/Scripts/Views/*.js",
                    "~/Scripts/Components/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Content/circle.css",
                      "~/Content/site.css"));
        }
    }
}
