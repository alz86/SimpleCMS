using DecisionTree.Plugins.SimpleCMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DecisionTree.Plugins.SimpleCMS.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SimpleCMSPageModel : AbpPageModel
{
    protected SimpleCMSPageModel()
    {
        LocalizationResourceType = typeof(SimpleCMSResource);
        ObjectMapperContext = typeof(SimpleCMSWebModule);
    }
}
