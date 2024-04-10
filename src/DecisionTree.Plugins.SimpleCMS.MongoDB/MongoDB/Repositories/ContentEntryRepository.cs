using DecisionTree.Plugins.SimpleCMS.Entities;
using DecisionTree.Plugins.SimpleCMS.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace DecisionTree.Plugins.SimpleCMS.MongoDB.Repositories
{
    public class ContentEntryRepository :
        MongoDbRepository<SimpleCMSMongoDbContext, ContentEntry, Guid>, IContentEntryRepository
    {
        public ContentEntryRepository(IMongoDbContextProvider<SimpleCMSMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ContentEntry>> GetAllAsync(bool includeContent = false)
        {
            //Note: this method is very similar to the one in the EntityFrameworkCore
            //implementation. However, to create something like a base class to put the
            //shared logic there would be an overkill for this situation.
            var query = await GetMongoQueryableAsync();
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
