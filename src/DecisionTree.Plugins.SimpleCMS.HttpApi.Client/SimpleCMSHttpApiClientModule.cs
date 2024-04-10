using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(SimpleCMSApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class SimpleCMSHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(SimpleCMSApplicationContractsModule).Assembly,
            SimpleCMSRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SimpleCMSHttpApiClientModule>();
        });

    }
}
