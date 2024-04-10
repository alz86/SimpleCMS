using System.Threading.Tasks;
using DecisionTree.Plugins.SimpleCMS.Dto;
using DecisionTree.Plugins.SimpleCMS.Services;
using Shouldly;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace DecisionTree.Plugins.SimpleCMS.ContentEntry;

public abstract class ContentEntryAppService_Tests<TStartupModule> : SimpleCMSApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IContentEntryAppService _contentEntryAppService;

    public ContentEntryAppService_Tests()
    {
        _contentEntryAppService = GetRequiredService<IContentEntryAppService>();
    }

    [Fact]
    public async Task GetAsync_ShouldReturnContentEntryDto_WhenIdIsValid()
    {
        // Arrange
        var testId = SimpleCMSTestData.Entry1Id;

        // Act
        var result = await _contentEntryAppService.GetAsync(testId);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(testId);
        result.Name.ShouldBe("Entry 1");
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntries()
    {
        // Arrange

        // Act
        var results = await _contentEntryAppService.GetAllAsync();

        // Assert
        results.ShouldNotBeNull();
        results.Count.ShouldBe(3);
    }

    #region Create / Update test methods

    [Fact]
    public async Task Insert_ShouldFail_WithoutName()
    {
        // Arrange
        var entry = GetTestCreateUpdateDto();
        entry.Name = "";

        // Act / Assert
        await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _contentEntryAppService.CreateAsync(entry);
        });
    }

    [Fact]
    public async Task Insert_ShouldFail_WithName_TooLong()
    {
        // Arrange
        var entry = GetTestCreateUpdateDto();
        entry.Name = new string('a', SimpleCMSConsts.FieldsConfiguration.NameMaxLength + 1);

        // Act / Assert
        await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _contentEntryAppService.CreateAsync(entry);
        });
    }


    [Fact]
    public async Task Insert_ShouldFail_WithoutTitle()
    {
        // Arrange
        var entry = GetTestCreateUpdateDto();
        entry.Title = "";

        // Act / Assert
        await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _contentEntryAppService.CreateAsync(entry);
        });
    }

    [Fact]
    public async Task Insert_ShouldFail_WithTitle_TooLong()
    {
        // Arrange
        var entry = GetTestCreateUpdateDto();
        entry.Title = new string('a', SimpleCMSConsts.FieldsConfiguration.TitleMaxLength + 1);

        // Act / Assert
        await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _contentEntryAppService.CreateAsync(entry);
        });
    }

    [Fact]
    public async Task Insert_ShouldFail_WithoutContent()
    {
        // Arrange
        var entry = GetTestCreateUpdateDto();
        entry.Content = "";

        // Act / Assert
        await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _contentEntryAppService.CreateAsync(entry);
        });
    }

    [Fact]
    public async Task Insert_ShouldFail_WithContent_TooLong()
    {
        // Arrange
        var entry = GetTestCreateUpdateDto();
        entry.Content = new string('a', SimpleCMSConsts.FieldsConfiguration.ContentMaxLength + 1);

        // Act / Assert
        await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _contentEntryAppService.CreateAsync(entry);
        });
    }

    #endregion


    private CreateUpdateContentEntryDto GetTestCreateUpdateDto() => new()
    {
        Name = "Test name",
        Title = "Test title",
        Content = "Test content"
    };

}
