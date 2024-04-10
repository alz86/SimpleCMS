using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DecisionTree.Plugins.SimpleCMS.Dto;
using DecisionTree.Plugins.SimpleCMS.Entities;
using DecisionTree.Plugins.SimpleCMS.Permissions;
using DecisionTree.Plugins.SimpleCMS.Repositories;
using DecisionTree.Plugins.SimpleCMS.Services;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.ChangeTracking;

namespace DecisionTree.Plugins.SimpleCMS.Application;

public class ContentEntryAppService :
        CrudAppService<ContentEntry, ContentEntryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateContentEntryDto>,
        IContentEntryAppService
{
    public ContentEntryAppService(IContentEntryRepository repository) : base(repository)
    {
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <remarks>
    /// This version uses the No tracking EF feature to improve performance.
    /// </remarks>
    [DisableEntityChangeTracking]
    public override Task<ContentEntryDto> GetAsync(Guid id) => base.GetAsync(id);

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [DisableEntityChangeTracking]
    public async Task<ReadOnlyCollection<ContentEntryDto>> GetAllAsync(bool includeContent = false)
    {
        var entities = await (Repository as IContentEntryRepository)!.GetAllAsync(includeContent);
        return ObjectMapper.Map<List<ContentEntry>, List<ContentEntryDto>>(entities).AsReadOnly();
    }


    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [DisableEntityChangeTracking]
    public Task<PagedResultDto<ContentEntryDto>> GetAllPagedAsync(PagedAndSortedResultRequestDto dto)
    {
        return base.GetListAsync(dto);
    }

    [Authorize(SimpleCMSPermissions.EditContentPermission)]
    public override Task<ContentEntryDto> CreateAsync(CreateUpdateContentEntryDto input) => base.CreateAsync(input);

    [Authorize(SimpleCMSPermissions.EditContentPermission)]
    public override Task<ContentEntryDto> UpdateAsync(Guid id, CreateUpdateContentEntryDto input) => base.UpdateAsync(id, input);
}
