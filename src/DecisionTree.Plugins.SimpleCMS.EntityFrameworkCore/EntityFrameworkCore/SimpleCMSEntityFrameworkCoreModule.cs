using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore;

[DependsOn(
    typeof(SimpleCMSDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SimpleCMSEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SimpleCMSDbContext>(options =>
        {
            options.AddDefaultRepositories<ISimpleCMSDbContext>();
        });
    }
}
