using DecisionTree.Plugins.SimpleCMS.Repositories;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace DecisionTree.Plugins.SimpleCMS;
public class SimpleCMSDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly ICurrentTenant _currentTenant;
    private readonly IContentEntryRepository _contentEntryRepository;

    public SimpleCMSDataSeedContributor(
        ICurrentTenant currentTenant, IContentEntryRepository contentEntryRepository)
    {
        _currentTenant = currentTenant;
        _contentEntryRepository = contentEntryRepository;
    }
    
    public async Task SeedAsync(DataSeedContext context)
    {
        var Entry1 = new MockedContentEntry()
        {
            WritableId = SimpleCMSTestData.Entry1Id,
            Name = "Entry 1",
            Title = "Title 1",
            Content = "Content 1"
        };
        var Entry2 = new MockedContentEntry
        {
            WritableId = SimpleCMSTestData.Entry2Id,
            Name = "Entry 2",
            Title = "Title 2",
            Content = "Content 2"
        };
        var Entry3 = new MockedContentEntry
        {
            WritableId = SimpleCMSTestData.Entry3Id,
            Name = "Entry 3",
            Title = "Title 3",
            Content = "Content 3"
        };
        using (_currentTenant.Change(context?.TenantId))
        {
            await _contentEntryRepository.InsertManyAsync([Entry1, Entry2, Entry3]);
        }
    }
}