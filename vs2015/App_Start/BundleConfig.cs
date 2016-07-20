using System.Web;
using System.Web.Optimization;

namespace vs2015
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-1.9.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryCrop").Include(
                        "~/Scripts/jquery-1.9.1.min.js",
                        "~/Scripts/jquery-ui-1.9.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/fileupload").Include(
                        "~/Scripts/jquery.fileupload.js",
                        "~/Scripts/jquery.fileupload-ui.js",
                        "~/Scripts/jquery.iframe-transport.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendar").Include(
                        "~/scripts/moment.min.js",
                        "~/scripts/fullcalendar.min.js",
                        "~/scripts/lang/pt-br.js"));
        }
    }
}
