using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS.Blazor.WebAssembly;

[DependsOn(
    typeof(SimpleCMSBlazorModule),
    typeof(SimpleCMSHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class SimpleCMSBlazorWebAssemblyModule : AbpModule
{

}
