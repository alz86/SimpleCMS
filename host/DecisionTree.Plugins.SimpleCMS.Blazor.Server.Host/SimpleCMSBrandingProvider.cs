using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DecisionTree.Plugins.SimpleCMS.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class SimpleCMSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SimpleCMS";
}
