using DecisionTree.Plugins.SimpleCMS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DecisionTree.Plugins.SimpleCMS.Repositories
{
    public interface IContentEntryRepository : IRepository<ContentEntry, Guid>
    {
        /// <summary>
        /// Gets the complete list of content entries.
        /// </summary>
        /// <param name="includeContent">
        /// Value indicating whether the content of the
        /// <see cref="ContentEntry.Content"/> field should be included. 
        /// </param>
        /// <remarks>
        /// Note that the <see cref="ContentEntry.Content"/> field might have
        /// a large amount of data, so it is recommended to include this 
        /// information only when it be striclty necessary.
        Task<List<ContentEntry>> GetAllAsync(bool includeContent = false);
    }
}
