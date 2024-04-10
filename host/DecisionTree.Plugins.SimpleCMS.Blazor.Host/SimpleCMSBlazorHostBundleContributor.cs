using Volo.Abp.Bundling;

namespace DecisionTree.Plugins.SimpleCMS.Blazor.Host;

public class SimpleCMSBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
