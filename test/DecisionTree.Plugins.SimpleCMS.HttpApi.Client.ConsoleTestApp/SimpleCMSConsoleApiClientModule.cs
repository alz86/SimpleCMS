using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SimpleCMSHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class SimpleCMSConsoleApiClientModule : AbpModule
{

}
