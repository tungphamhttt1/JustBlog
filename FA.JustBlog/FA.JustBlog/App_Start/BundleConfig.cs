using System.Web;
using System.Web.Optimization;

namespace FA.JustBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Assets/js/jquery-{version}.js",
                "~/Assets/bower_components/fastclick/lib/fastclick.js",
                "~/Assets/dist/js/adminlte.min.js",
                "~/Assets/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js",
                "~/Assets/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                "~/Assets/select2/select2.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Assets/js/jquery.validate.min"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Assets/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Assets/js/bootstrap.min.js",
                "~/Assets/js/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Assets/css/bootstrap.min.css",
                "~/Assets/css/site.css",
                "~/Assets/bower_components/font-awesome/css/font-awesome.min.css",
                "~/Assets/bower_components/Ionicons/css/ionicons.min.css",
                "~/Assets/bower_components/jvectormap/jquery-jvectormap.css",
                "~/Assets/dist/css/AdminLTE.min.css",
                "~/Assets/dist/css/skins/_all-skins.min.css",
                "~/Assets/select2/select2.min.css"));
        }
    }
}
