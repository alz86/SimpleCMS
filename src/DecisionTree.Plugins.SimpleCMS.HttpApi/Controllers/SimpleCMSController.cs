using DecisionTree.Plugins.SimpleCMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DecisionTree.Plugins.SimpleCMS.Controllers;

public abstract class SimpleCMSController : AbpControllerBase
{
    protected SimpleCMSController()
    {
        LocalizationResource = typeof(SimpleCMSResource);
    }
}
