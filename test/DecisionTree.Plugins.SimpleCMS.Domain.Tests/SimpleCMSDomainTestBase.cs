using Volo.Abp.Modularity;

namespace DecisionTree.Plugins.SimpleCMS;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class SimpleCMSDomainTestBase<TStartupModule> : SimpleCMSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
