using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using DecisionTree.Plugins.SimpleCMS.Localization;
using DecisionTree.Plugins.SimpleCMS.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using DecisionTree.Plugins.SimpleCMS.Permissions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DecisionTree.Plugins.SimpleCMS.Web;

[DependsOn(
    typeof(SimpleCMSApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    )]
public class SimpleCMSWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(SimpleCMSResource), typeof(SimpleCMSWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SimpleCMSWebModule).Assembly);

            mvcBuilder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(SimpleCMSWebModule).Assembly));

        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new SimpleCMSMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SimpleCMSWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<SimpleCMSWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SimpleCMSWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
            options.Conventions.AuthorizePage("/SimpleCMS/Index", SimpleCMSPermissions.EditContentPermission);
            options.Conventions.AuthorizePage("/SimpleCMS/CreateModal", SimpleCMSPermissions.EditContentPermission);
        });
    }
}
