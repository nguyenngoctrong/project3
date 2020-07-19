using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using System.Web;
using System.Web.Optimization;

namespace project3
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/Scripts/axios").Include(
                      "~/Scripts/axios.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                          //"~/Scripts/jquery.unobtrusive-ajax.js",
                          "~/Scripts/jquery.validate.min.js",
                          "~/Scripts/jquery.validate.unobtrusive.min.js"
                          ));
            bundles.Add(new StyleBundle("~/icon/css").Include(
                      "~/fontawesome/css/all.min.css"
                      ));
            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                      "~/Content/bootstrap.min.css"
                      ));
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/jquery/js").Include(
                      "~/Scripts/jquery-3.5.1.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/Bundles/Scripts/main").Include(
                      "~/Scripts/page/main.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Scripts/home").Include(
                      "~/Scripts/page/home.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Scripts/product").Include(
                      "~/Scripts/page/product.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Scripts/profile").Include(
                      "~/Scripts/page/profile.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Scripts/purchase").Include(
                      "~/Scripts/page/purchase.js"));

            //SCSS
            bundles.Add(new CustomStyleBundle("~/Bundle/sass").Include(
                      "~/css/reset.scss"));
            bundles.Add(new CustomStyleBundle("~/Bundle/home").Include(
                      "~/css/home.scss"));
            bundles.Add(new CustomStyleBundle("~/Bundle/main").Include(
                      "~/css/main.scss"));
            bundles.Add(new CustomStyleBundle("~/Bundle/product").Include(
                      "~/css/product.scss"));
            bundles.Add(new CustomStyleBundle("~/Bundle/profile").Include(
                      "~/css/profile.scss"));
            bundles.Add(new CustomStyleBundle("~/Bundle/purchase").Include(
                      "~/css/purchase.scss"));
        }
    }
}
