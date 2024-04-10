using Volo.Abp;
using Volo.Abp.MongoDB;

namespace DecisionTree.Plugins.SimpleCMS.MongoDB;

public static class SimpleCMSMongoDbContextExtensions
{
    public static void ConfigureSimpleCMS(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
