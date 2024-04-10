using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(SimpleCMSApplicationModule),
    typeof(SimpleCMSDomainTestModule)
    )]
public class SimpleCMSApplicationTestModule : AbpModule
{

}
