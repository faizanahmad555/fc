using System.Web;
using System.Web.Optimization;

namespace MultivendorEcommerceStore
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


            bundles.Add(new ScriptBundle("~/bundles/ThemeScript").Include(
                     "~/assets/lib/bootstrap/js/bootstrap.min.js",
                     "~/Scripts/respond.js",
                     "~/assets/lib/select2/js/select2.min.js",
                     "~/assets/lib/jquery.bxslider/jquery.bxslider.min.js",
                     "~/assets/lib/owl.carousel/owl.carousel.min.js",
                     "~/assets/lib/countdown/jquery.plugin.js",
                     "~/assets/lib/jquery.countdown/jquery.countdown.min.js",
                     "~/assets/js/jquery.actual.min.js",
                     "~/assets/js/theme-script.js"
                     ));

            bundles.Add(new StyleBundle("~/Assets/css").Include(
                //"~/assets/lib/bootstrap/css/bootstrap.css",
                "~/assets/lib/font-awesome/css/font-awesome.min.css",
                "~/assets/lib/select2/css/select2.min.css",
                "~/assets/lib/jquery.bxslider/jquery.bxslider.css",
                "~/assets/lib/owl.carousel/owl.carousel.css",
                "~/assets/lib/jquery-ui/jquery-ui.css",
                "~/assets/css/animate.css",
                "~/assets/css/reset.css",
                "~/assets/css/style.css",
                "~/assets/css/responsive.css",
                "~/assets/css/option5.css"));
               // "~/Content/site.css"));
          //   BundleTable.EnableOptimizations = false; // when this is not false
        }
    }
}
