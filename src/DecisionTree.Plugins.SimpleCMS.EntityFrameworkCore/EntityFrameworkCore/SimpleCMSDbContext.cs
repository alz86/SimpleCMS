using DecisionTree.Plugins.SimpleCMS.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore;

[ConnectionStringName(SimpleCMSDbProperties.ConnectionStringName)]
public class SimpleCMSDbContext : AbpDbContext<SimpleCMSDbContext>, ISimpleCMSDbContext
{
    public DbSet<ContentEntry> ContentEntries { get; set; }

    public SimpleCMSDbContext(DbContextOptions<SimpleCMSDbContext> options)
        : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSimpleCMS();
    }
}
