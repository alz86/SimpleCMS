using DecisionTree.Plugins.SimpleCMS.MongoDB.Repositories;
using DecisionTree.Plugins.SimpleCMS.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace DecisionTree.Plugins.SimpleCMS.MongoDB;

[DependsOn(
    typeof(SimpleCMSDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class SimpleCMSMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<SimpleCMSMongoDbContext>(options => { });
        context.Services.AddTransient<IContentEntryRepository, ContentEntryRepository>();
    }
}
