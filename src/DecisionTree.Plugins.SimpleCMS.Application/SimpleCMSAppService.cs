using DecisionTree.Plugins.SimpleCMS.Localization;
using Volo.Abp.Application.Services;

namespace DecisionTree.Plugins.SimpleCMS;

public abstract class SimpleCMSAppService : ApplicationService
{
    protected SimpleCMSAppService()
    {
        LocalizationResource = typeof(SimpleCMSResource);
        ObjectMapperContext = typeof(SimpleCMSApplicationModule);
    }
}
