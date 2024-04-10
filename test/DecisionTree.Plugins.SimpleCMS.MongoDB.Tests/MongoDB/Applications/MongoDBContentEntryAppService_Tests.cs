using DecisionTree.Plugins.SimpleCMS.MongoDB;
using DecisionTree.Plugins.SimpleCMS.ContentEntry;
using Xunit;

namespace DecisionTree.Plugins.SimpleCMS.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBContentEntryAppService_Tests : ContentEntryAppService_Tests<SimpleCMSMongoDbTestModule>
{

}
