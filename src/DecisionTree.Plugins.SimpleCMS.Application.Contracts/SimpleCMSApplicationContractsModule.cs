using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(SimpleCMSDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class SimpleCMSApplicationContractsModule : AbpModule
{
}
