using DecisionTree.Plugins.SimpleCMS.Repositories;
using Xunit;

namespace DecisionTree.Plugins.SimpleCMS.MongoDB.Repositories;

[Collection(MongoTestCollection.Name)]
public class ContentEntryRepository_Tests : ContentEntryRepository_Tests<SimpleCMSMongoDbTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to MongoDB.
     */
    public ContentEntryRepository_Tests() : base()
    {
    }
}
