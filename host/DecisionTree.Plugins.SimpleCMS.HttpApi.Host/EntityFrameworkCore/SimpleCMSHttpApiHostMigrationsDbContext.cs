using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore;

public class SimpleCMSHttpApiHostMigrationsDbContext : AbpDbContext<SimpleCMSHttpApiHostMigrationsDbContext>
{
    public SimpleCMSHttpApiHostMigrationsDbContext(DbContextOptions<SimpleCMSHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureSimpleCMS();
    }
}
