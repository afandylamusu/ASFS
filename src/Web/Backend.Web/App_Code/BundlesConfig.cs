using System.Web.Optimization;

namespace Backend.Web
{
    public class BundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var appts = new ScriptBundle("~/bundles/appts")
                        .IncludeDirectory("~/Scripts/app", "*.js");

            bundles.Add(appts);

            bundles.IgnoreList.Ignore("*.map.js", OptimizationMode.Always);

            // Code removed for clarity.
#if DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }

    }
}