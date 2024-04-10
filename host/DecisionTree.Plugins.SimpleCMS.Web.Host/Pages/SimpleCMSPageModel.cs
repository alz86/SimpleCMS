using DecisionTree.Plugins.SimpleCMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DecisionTree.Plugins.SimpleCMS.Pages;

public abstract class SimpleCMSPageModel : AbpPageModel
{
    protected SimpleCMSPageModel()
    {
        LocalizationResourceType = typeof(SimpleCMSResource);
    }
}
