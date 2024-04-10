using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace DecisionTree.Plugins.SimpleCMS.Blazor.Menus;

public class SimpleCMSMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(SimpleCMSMenus.Prefix, displayName: "SimpleCMS", "/SimpleCMS", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
