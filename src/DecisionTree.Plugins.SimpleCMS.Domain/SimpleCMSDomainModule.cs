using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SimpleCMSDomainSharedModule)
)]
public class SimpleCMSDomainModule : AbpModule
{

}
