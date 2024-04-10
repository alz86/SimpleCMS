using DecisionTree.Plugins.SimpleCMS.Dto;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DecisionTree.Plugins.SimpleCMS.Services
{
    public interface IContentEntryAppService : ICrudAppService<
            ContentEntryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateContentEntryDto>
    {
        /// <summary>
        /// Gets the complete list of content entries 
        /// in the system.
        /// </summary>
        /// <remarks>
        /// Whilst Abp.io already provides a method to get a paged list of content entries,
        /// it is capped internally to a maximum of 1000 entries. This method is intended to
        /// return the whole list of entries, not because it would be usefull (the paged version
        /// is the one to be used), but to complete the task that explicitly asks for the whole list.
        /// </remarks>
        Task<ReadOnlyCollection<ContentEntryDto>> GetAllAsync(bool includeContent = false);

        /// <summary>
        /// Gets a paged list of content entries.
        /// </summary>
        /// <remarks>
        /// This method was created because the Asp.net MVC DataTable
        /// component requires a method that returns objects of this type
        /// to work properly. Then, while GetAllAsync is the method required
        /// by the task, this one was added to take advantage of the built-in 
        /// client components the framework has.
        /// </remarks>
        Task<PagedResultDto<ContentEntryDto>> GetAllPagedAsync(PagedAndSortedResultRequestDto dto);


    }
}
