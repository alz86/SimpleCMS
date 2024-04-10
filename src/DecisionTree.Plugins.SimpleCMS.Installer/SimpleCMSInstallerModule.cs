using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class SimpleCMSInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SimpleCMSInstallerModule>();
        });
    }
}
