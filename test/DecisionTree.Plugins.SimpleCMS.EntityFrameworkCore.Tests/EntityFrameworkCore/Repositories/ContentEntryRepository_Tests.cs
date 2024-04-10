using DecisionTree.Plugins.SimpleCMS.Repositories;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore.Repositories;

public class ContentEntryRepository_Tests : ContentEntryRepository_Tests<SimpleCMSEntityFrameworkCoreTestModule>
{
    /* Don't write custom repository tests here, instead write to
     * the base class.
     * One exception can be some specific tests related to EF core.
     */
    public ContentEntryRepository_Tests() : base()
    {
    }
}
