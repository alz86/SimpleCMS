using DecisionTree.Plugins.SimpleCMS.Dto;
using DecisionTree.Plugins.SimpleCMS.Services;
using DecisionTree.Plugins.SimpleCMS.Web.ViewModels;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DecisionTree.Plugins.SimpleCMS.Pages.SimpleCMS
{
    public class PagesModel : AbpPageModel
    {
        private readonly IContentEntryAppService _contentEntryAppService;

        public PagesModel(IContentEntryAppService contentEntryAppService)
        {
            _contentEntryAppService = contentEntryAppService;
        }

        public ContentEntryViewModel ContentEntryInfo { get; set; }

        public async Task OnGet(Guid id)
        {
            var entry = await _contentEntryAppService.GetAsync(id);
            ContentEntryInfo = ObjectMapper.Map<ContentEntryDto, ContentEntryViewModel>(entry);
        }
    }
}
