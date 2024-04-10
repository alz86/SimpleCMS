using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(SimpleCMSDomainModule),
    typeof(SimpleCMSTestBaseModule)
)]
public class SimpleCMSDomainTestModule : AbpModule
{

}
