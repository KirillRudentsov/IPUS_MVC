﻿using System.Web;
using System.Web.Optimization;

namespace Kendo_Example
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/Scripts/kendo").Include(
            "~/Scripts/kendo/2019.1.220/kendo.all.min.js",
            "~/Scripts/kendo/2019.1.220/kendo.timezones.min.js",
            "~/Scripts/kendo/2019.1.220/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Custom").Include(
                "~/Scripts/Custom/Alertify.js", "~/Scripts/Custom/DynamicCreatorComponent.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Cultures").Include(
                "~/Scripts/Cultures/kendo.culture.ru-RU.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/messages").Include(
                "~/Scripts/Cultures/kendo.messages.ru-RU.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
            "~/Content/kendo/2019.1.220/kendo.common.min.css",
            "~/Content/kendo/2019.1.220/kendo.default.min.css"));

            //bundles.IgnoreList.Clear();
            BundleTable.EnableOptimizations = false;
        }
    }
}
