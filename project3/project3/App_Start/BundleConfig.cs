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

            bundles.Add(new ScriptBundle("~/Bundles/Scripts/main").Include(
                      "~/Scripts/main.js"));
            bundles.Add(new ScriptBundle("~/Bundles/Scripts/home").Include(
                      "~/Scripts/home.js"));
            bundles.Add(new StyleBundle("~/icon/css").Include(
                      "~/fontawesome/css/all.min.css"
                      ));
            bundles.Add(new CustomStyleBundle("~/Bundle/sass").Include(
                      "~/css/reset.scss"));
            bundles.Add(new CustomStyleBundle("~/Bundle/home").Include(
                      "~/css/home.scss"));
            bundles.Add(new CustomStyleBundle("~/Bundle/main").Include(
                      "~/css/main.scss"));
            //var nullBulider = new NullBuilder();
            //var nullOrderer = new NullOrderer();

            //BundleResolver.Current = new CustomBundleResolver();
            //var commonStyleBundle = new CustomStyleBundle("~/Bundle/sass");

            //commonStyleBundle.Include("~/css/reset.scss");
            //commonStyleBundle.Orderer = nullOrderer;
            //bundles.Add(commonStyleBundle);
        }
    }
}
