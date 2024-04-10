using DecisionTree.Plugins.SimpleCMS.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DecisionTree.Plugins.SimpleCMS.Blazor.Server.Host;

public abstract class SimpleCMSComponentBase : AbpComponentBase
{
    protected SimpleCMSComponentBase()
    {
        LocalizationResource = typeof(SimpleCMSResource);
    }
}
