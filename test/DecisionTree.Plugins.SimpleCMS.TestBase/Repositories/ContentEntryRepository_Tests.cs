using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace DecisionTree.Plugins.SimpleCMS.Repositories;

/* Write your custom repository tests like that, in this project, as abstract classes.
 * Then inherit these abstract classes from EF Core & MongoDB test projects.
 * In this way, both database providers are tests with the same set tests.
 */
public abstract class ContentEntryRepository_Tests<TStartupModule> : SimpleCMSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IContentEntryRepository _contentEntryRepository;

    protected ContentEntryRepository_Tests()
    {
        _contentEntryRepository = GetRequiredService<IContentEntryRepository>();
    }

    [Fact]
    public async Task GetListAsync_ShouldFilterContent()
    {
        // Arrange

        // Act
        var result = await _contentEntryRepository.GetAllAsync(false);

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        foreach (var content in result)
        {
            content.Content.ShouldBeNullOrEmpty();
        }
    }

    [Fact]
    public async Task GetListAsync_ShouldNotFilterContent()
    {
        // Arrange

        // Act
        var result = await _contentEntryRepository.GetAllAsync(true);

        // Assert
        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        foreach (var content in result)
        {
            content.Content.ShouldNotBeNullOrEmpty();
        }
    }
}
