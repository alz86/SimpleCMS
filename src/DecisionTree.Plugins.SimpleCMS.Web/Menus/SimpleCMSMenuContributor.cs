using DecisionTree.Plugins.SimpleCMS.Localization;
using DecisionTree.Plugins.SimpleCMS.Permissions;
using DecisionTree.Plugins.SimpleCMS.Services;
using Microsoft.Extensions.DependencyInjection;
using NUglify.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace DecisionTree.Plugins.SimpleCMS.Web.Menus;

public class SimpleCMSMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var contentEntryAppService = context.ServiceProvider.GetRequiredService<IContentEntryAppService>();
        var localizedTexts = context.GetLocalizer<SimpleCMSResource>();

        //menu item for managing new page
        context.Menu.Items.Add(new ApplicationMenuItem(
            name: SimpleCMSMenus.ManageItemName,
            displayName: localizedTexts[SimpleCMSConsts.LocalizedTexts.ManagePageMenuItem],
            url: $"~/{SimpleCMSMenus.PagesRoute}/",
            icon: "fa fa-cog",
            requiredPermissionName: SimpleCMSPermissions.EditContentPermission));

        //looks for existing content entries and adds them to the menu
        var existingContents = await contentEntryAppService.GetAllAsync(false);
        if (existingContents.Any())
        {
            existingContents.Select(e =>
                new ApplicationMenuItem(
                    name: e.Name,
                    displayName: e.Title,
                    url: $"~/{SimpleCMSMenus.PagesRoute}/pages/{e.Id}",
                    icon: "fa fa-file"
                ))
                .ForEach(item => context.Menu.AddItem(item));
        }
    }
}
