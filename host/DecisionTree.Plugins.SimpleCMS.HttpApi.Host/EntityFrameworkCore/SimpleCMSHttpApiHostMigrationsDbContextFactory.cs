using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore;

public class SimpleCMSHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<SimpleCMSHttpApiHostMigrationsDbContext>
{
    public SimpleCMSHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SimpleCMSHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("SimpleCMS"));

        return new SimpleCMSHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
