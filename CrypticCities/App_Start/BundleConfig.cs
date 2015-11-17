using System.Web;
using System.Web.Optimization;

namespace CrypticCities
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/sb-admin/css").Include(
                      "~/Content/sb-admin/css/bootstrap.css",
                      "~/Content/sb-admin/css/sb-admin.css",
                      "~/Content/sb-admin/font-awesome/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/stylish/css").Include(
                      "~/Content/stylish/css/bootstrap.css",
                      "~/Content/stylish/css/stylish-portfolio.css",
                      "~/Content/stylish/font-awesome/css/font-awesome.css"));

            bundles.Add(new ScriptBundle("~/bundles/sb-admin").Include(
                      "~/Content/sb-admin/js/bootstrap.js"));
        }
    }
}
