using DecisionTree.Plugins.SimpleCMS.Dto;
using DecisionTree.Plugins.SimpleCMS.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace DecisionTree.Plugins.SimpleCMS.Controllers
{
    [Route("api/simpleCMS/entry")]
    public class ContentEntryController : SimpleCMSController
    {
        private readonly IContentEntryAppService _contentEntryAppService;

        public ContentEntryController(IContentEntryAppService contentEntryAppService)
        {
            _contentEntryAppService = contentEntryAppService;
        }

        [HttpPost]
        [Route("{id?}")]
        public Task<ContentEntryDto> InsertOrUpdateCMSContent(Guid? id, [FromBody] CreateUpdateContentEntryDto entryDto)
        {
            var isCreating = id == null || id == Guid.Empty;
            return isCreating
                ? _contentEntryAppService.CreateAsync(entryDto)
                : _contentEntryAppService.UpdateAsync(id!.Value, entryDto);
        }

        [HttpGet]
        [Route("{entryId}")]
        public Task<ContentEntryDto> GetCMSContent(Guid entryId) => _contentEntryAppService.GetAsync(entryId);

        [HttpGet]
        public Task<ReadOnlyCollection<ContentEntryDto>> GetAll() => _contentEntryAppService.GetAllAsync();

        [HttpGet]
        [Route("/paged")]
        public Task<PagedResultDto<ContentEntryDto>> GetAllPaged(PagedAndSortedResultRequestDto dto) => _contentEntryAppService.GetAllPagedAsync(dto);
    }

}
