using System.Web;
using System.Web.Optimization;

namespace CrypticCities
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*
            Imporant note!

            When using bundling, if the css files link to other resources (fonts, imgs, etc) using relative paths,
            they wont work out of the box with bundling:

            You need to use the CssRewriteUrlTransform in each include to have it change the relative paths
            This also requires that the minified css files aren't present, otherwise it will just use those, 
            and no re-write will happen on the urls.
            */


            BundleTable.EnableOptimizations = true;
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

            bundles.Add(new StyleBundle("~/styles/sb-admin").Include(
                      "~/Content/sb-admin/css/bootstrap.css",
                      "~/Content/sb-admin/css/sb-admin-2.css",
                      "~/Content/font-awesome/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/styles/sb-admin-2").Include(
                      "~/Content/sb-admin-2/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Content/sb-admin-2/dist/css/sb-admin-2.css",
                      "~/Content/sb-admin-2/bower_components/metisMenu/dist/metisMenu.css"
                      ).Include("~/Content/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/styles/stylish")
                .Include("~/Content/stylish/css/*.css", new CssRewriteUrlTransform())
                .Include("~/Content/font-awesome/css/*.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/sb-admin").Include(
                      "~/Content/sb-admin/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/sb-admin-2").Include(
                      "~/Content/sb-admin-2/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/Content/sb-admin-2/bower_components/metisMenu/dist/metisMenu.js",
                      "~/Content/sb-admin-2/dist/js/sb-admin-2.js"));            
        }
    }
}
