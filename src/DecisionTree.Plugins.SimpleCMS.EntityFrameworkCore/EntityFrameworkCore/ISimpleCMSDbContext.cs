using DecisionTree.Plugins.SimpleCMS.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore;

[ConnectionStringName(SimpleCMSDbProperties.ConnectionStringName)]
public interface ISimpleCMSDbContext : IEfCoreDbContext
{
    DbSet<ContentEntry> ContentEntries { get; }
}
