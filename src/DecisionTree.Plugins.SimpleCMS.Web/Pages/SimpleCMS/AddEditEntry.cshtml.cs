using DecisionTree.Plugins.SimpleCMS.Dto;
using DecisionTree.Plugins.SimpleCMS.Services;
using DecisionTree.Plugins.SimpleCMS.Web;
using DecisionTree.Plugins.SimpleCMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DecisionTree.Plugins.SimpleCMS.Pages.SimpleCMS
{
    public class AddEditEntryModel : AbpPageModel
    {
        private readonly IContentEntryAppService _contentEntryAppService;
        private readonly IAuthorizationService _authorization;

        public AddEditEntryModel(IContentEntryAppService contentEntryAppService, IAuthorizationService authorization)
        {
            ObjectMapperContext = typeof(SimpleCMSWebModule);
            _contentEntryAppService = contentEntryAppService;
            _authorization = authorization;
        }

        [BindProperty]
        public ContentEntryViewModel? ContentEntryInfo { get; set; }

        public virtual async Task<ActionResult> OnGetAsync(Guid? id)
        {
            if (id != null)
            {
                var entry = await _contentEntryAppService.GetAsync(id.Value);
                ContentEntryInfo = ObjectMapper.Map<ContentEntryDto, ContentEntryViewModel>(entry);
            }

            return Page();
        }

        public virtual async Task<ActionResult> OnPostAsync()
        {
            ValidateModel();

            var input = ObjectMapper.Map<ContentEntryViewModel, CreateUpdateContentEntryDto>(ContentEntryInfo!);

            var isCreating = ContentEntryInfo!.Id == null;
            await (isCreating ? _contentEntryAppService.CreateAsync(input) : _contentEntryAppService.UpdateAsync(ContentEntryInfo.Id!.Value, input));

            return NoContent();
        }
    }
}
