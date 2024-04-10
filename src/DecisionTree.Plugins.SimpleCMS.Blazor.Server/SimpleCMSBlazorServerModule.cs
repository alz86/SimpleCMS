using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(SimpleCMSBlazorModule)
    )]
public class SimpleCMSBlazorServerModule : AbpModule
{

}
