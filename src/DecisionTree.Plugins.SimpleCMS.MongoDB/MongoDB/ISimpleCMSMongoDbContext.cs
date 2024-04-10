using DecisionTree.Plugins.SimpleCMS.Entities;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace DecisionTree.Plugins.SimpleCMS.MongoDB;

[ConnectionStringName(SimpleCMSDbProperties.ConnectionStringName)]
public interface ISimpleCMSMongoDbContext : IAbpMongoDbContext
{
    IMongoCollection<ContentEntry> ContentEntries { get; }
}
