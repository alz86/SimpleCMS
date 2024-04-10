using Localization.Resources.AbpUi;
using DecisionTree.Plugins.SimpleCMS.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(SimpleCMSApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SimpleCMSHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddControllersAsServices();
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SimpleCMSHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<SimpleCMSResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
