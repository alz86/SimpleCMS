using System;
using Volo.Abp.Application.Dtos;

namespace DecisionTree.Plugins.SimpleCMS.Dto
{
    public class ContentEntryDto : EntityDto<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}
