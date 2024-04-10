using DecisionTree.Plugins.SimpleCMS.Entities;
using DecisionTree.Plugins.SimpleCMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DecisionTree.Plugins.SimpleCMS.EntityFrameworkCore.Repositories
{
    public class ContentEntryRepository : EfCoreRepository<SimpleCMSDbContext, ContentEntry, Guid>, IContentEntryRepository
    {
        public ContentEntryRepository(IDbContextProvider<SimpleCMSDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ContentEntry>> GetAllAsync(bool includeContent = false)
        {
            //Note: this method is very similar to the one in the MongoDB
            //implementation. However, to create something like a base class to put the
            //shared logic there would be an overkill for this situation.
            var query = await GetQueryableAsync();
            if (!includeContent)
            {
                query = query.Select(x =>
                    new ContentEntry(x.Id)
                    {
                        Name = x.Name,
                        Title = x.Title,
                    });
            }

            return await query.ToListAsync();
        }

    }
}
