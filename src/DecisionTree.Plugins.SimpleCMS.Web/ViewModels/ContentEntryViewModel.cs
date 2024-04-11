using DecisionTree.Plugins.SimpleCMS.Dto.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace DecisionTree.Plugins.SimpleCMS.Web.ViewModels;

public class ContentEntryViewModel : ExtensibleObject
{
    [HiddenInput]
    public Guid? Id { get; set; } = null;

    [Required]
    [StringLength(SimpleCMSConsts.FieldsConfiguration.NameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(SimpleCMSConsts.FieldsConfiguration.TitleMaxLength)]
    public string Title { get; set; } = string.Empty;

    [StringLength(SimpleCMSConsts.FieldsConfiguration.ContentMaxLength)]
    [HtmlContentRequiredValidation]
    [HiddenInput]
    public string Content { get; set; } = string.Empty;
}
