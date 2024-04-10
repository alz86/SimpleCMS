using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DecisionTree.Plugins.SimpleCMS;

[Dependency(ReplaceServices = true)]
public class SimpleCMSBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SimpleCMS";
}
