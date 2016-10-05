using System.Web;
using System.Web.Optimization;

namespace MyDealTest
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/themes/base/jquery-ui.min.css",
            //    "~/Content/themes/ui-darkness/jquery-ui.ui-darkness.min.css",
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/create-url").Include(
                             "~/Scripts/jquery-{version}.js",
                              "~/Scripts/jquery.validate*",
                              "~/Scripts/bootstrap.js",
                             "~/Scripts/UrlRedirects/CreateUrl.js"
                           ));



            bundles.Add(new ScriptBundle("~/bundles/passengers").Include(
                             "~/Scripts/jquery-{version}.js",
                              "~/Scripts/bootstrap.js",
                             "~/Scripts/passengers/PassengerHome.js",
                            "~/Scripts/passengers/App.js",
                            "~/Scripts/passengers/Controller.js",
                            "~/Scripts/passengers/Service.js"

                           ));




        }
    }
}
