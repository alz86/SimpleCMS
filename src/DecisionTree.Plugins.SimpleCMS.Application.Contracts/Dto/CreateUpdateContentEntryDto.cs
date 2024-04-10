using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace DecisionTree.Plugins.SimpleCMS.Dto
{
    public class CreateUpdateContentEntryDto : EntityDto<Guid>
    {
        [Required]
        [StringLength(SimpleCMSConsts.FieldsConfiguration.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(SimpleCMSConsts.FieldsConfiguration.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(SimpleCMSConsts.FieldsConfiguration.ContentMaxLength)]
        public string Content { get; set; } = string.Empty;
    }
}
