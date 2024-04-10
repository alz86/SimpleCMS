using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace DecisionTree.Plugins.SimpleCMS.MongoDB;

[DependsOn(
    typeof(SimpleCMSApplicationTestModule),
    typeof(SimpleCMSMongoDbModule)
)]
public class SimpleCMSMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
