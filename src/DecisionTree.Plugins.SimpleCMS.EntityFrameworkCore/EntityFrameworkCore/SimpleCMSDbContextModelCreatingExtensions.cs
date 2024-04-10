using DecisionTree.Plugins.SimpleCMS.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore;

public static class SimpleCMSDbContextModelCreatingExtensions
{
    public static void ConfigureSimpleCMS(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<ContentEntry>(b =>
        {
            b.ToTable(
                $"{SimpleCMSDbProperties.DbTablePrefix}ContentEntries",
                SimpleCMSDbProperties.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props

            b.Property(x => x.Name).IsRequired().HasMaxLength(SimpleCMSConsts.FieldsConfiguration.NameMaxLength);
            b.Property(x => x.Title).IsRequired().HasMaxLength(SimpleCMSConsts.FieldsConfiguration.TitleMaxLength);
            b.Property(x => x.Content).IsRequired().HasMaxLength(SimpleCMSConsts.FieldsConfiguration.ContentMaxLength);
        });
    }
}
