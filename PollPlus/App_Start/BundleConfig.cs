using System.Web;
using System.Web.Optimization;

namespace PollPlus
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
            bundles.Add(
                new ScriptBundle("~/bundles/jquery.flot").Include(
                    "~/Scripts/Theme/jquery.flot/jquery.flot.js",
                    "~/Scripts/Theme/jquery.flot/jquery.flot.pie.js",
                    "~/Scripts/Theme/jquery.flot/jquery.flot.resize.js",
                    "~/Scripts/Theme/jquery.flot/jquery.flot.labels.js"));

            bundles.Add(new StyleBundle("~/Content/CssTheme0").Include(
                "~/Scripts/Theme/bootstrap/dist/css/bootstrap.css",
                "~/Scripts/Theme/jquery.gritter/css/jquery.gritter.css",
                "~/Scripts/Theme/jquery.nanoscroller/nanoscroller.css",
                "~/Scripts/Theme/jquery.codemirror/lib/codemirror.css",
                "~/Scripts/Theme/jquery.codemirror/theme/ambiance.css",
                "~/Scripts/Theme/jquery.vectormaps/jquery-jvectormap-1.2.2.css",
                "~/Content/Theme/css/style.css",
                "~/Scripts/Theme/bootstrap.multiselect/css/bootstrap-multiselect.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jsTheme0").Include(
                "~/Scripts/Theme/jquery.js",
                "~/Scripts/Theme/jquery.cookie/jquery.cookie.js",
                "~/Scripts/Theme/jquery.pushmenu/js/jPushMenu.js",
                "~/Scripts/Theme/jquery.nanoscroller/jquery.nanoscroller.js",
                "~/Scripts/Theme/jquery.sparkline/jquery.sparkline.min.js",
                "~/Scripts/Theme/jquery.ui/jquery-ui.js",
                "~/Scripts/Theme/jquery.gritter/js/jquery.gritter.js",
                "~/Scripts/Theme/behaviour/core.js",
                "~/Scripts/Theme/bootstrap.summernote/dist/summernote.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsTheme1").Include(
                "~/Scripts/Theme/jquery.codemirror/lib/codemirror.js",
                "~/Scripts/Theme/jquery.codemirror/mode/xml/xml.js",
                "~/Scripts/Theme/jquery.codemirror/mode/css/css.js",
                "~/Scripts/Theme/jquery.codemirror/mode/htmlmixed/htmlmixed.js",
                "~/Scripts/Theme/jquery.codemirror/addon/edit/matchbrackets.js",
                "~/Scripts/Theme/jquery.vectormaps/jquery-jvectormap-1.2.2.min.js",
                "~/Scripts/Theme/jquery.vectormaps/maps/jquery-jvectormap-world-mill-en.js",
                "~/Scripts/Theme/behaviour/dashboard.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsTheme2").Include(
                //"~/Scripts/Theme/behaviour/voice-commands.js",
                "~/Scripts/Theme/bootstrap/dist/js/bootstrap.min.js"
            //"~/Scripts/Theme/jquery.flot/jquery.flot.js",
            //"~/Scripts/Theme/jquery.flot/jquery.flot.pie.js",
            //"~/Scripts/Theme/jquery.flot/jquery.flot.resize.js",
            //"~/Scripts/Theme/jquery.flot/jquery.flot.labels.js"
            ));
        }
    }
}
