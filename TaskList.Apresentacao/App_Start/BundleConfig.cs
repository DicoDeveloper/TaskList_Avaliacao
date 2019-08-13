using System.Web.Optimization;

namespace TaskList.Apresentacao
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Terceiros/jquery-3.3.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Terceiros/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/Terceiros/materialize.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Terceiros/materialize.css",
                      "~/Content/site.css"));
        }
    }
}
