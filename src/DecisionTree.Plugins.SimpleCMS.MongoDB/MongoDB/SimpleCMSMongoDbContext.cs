using DecisionTree.Plugins.SimpleCMS.Entities;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DecisionTree.Plugins.SimpleCMS.MongoDB;

[ConnectionStringName(SimpleCMSDbProperties.ConnectionStringName)]
public class SimpleCMSMongoDbContext : AbpMongoDbContext, ISimpleCMSMongoDbContext
{
    public IMongoCollection<ContentEntry> ContentEntries => Collection<ContentEntry>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureSimpleCMS();
    }
}
