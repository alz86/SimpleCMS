using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class SimpleCMSApplicationTestBase<TStartupModule> : SimpleCMSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
