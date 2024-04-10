using AutoMapper;
using DecisionTree.Plugins.SimpleCMS.Dto;
using DecisionTree.Plugins.SimpleCMS.Web.ViewModels;
using Volo.Abp.AutoMapper;

namespace DecisionTree.Plugins.SimpleCMS.Web
{
    public class SimpleCMSWebAutoMapperProfile : Profile
    {
        public SimpleCMSWebAutoMapperProfile()
        {
            CreateMap<ContentEntryViewModel, CreateUpdateContentEntryDto>();
            CreateMap<ContentEntryDto, ContentEntryViewModel>()
                .Ignore(p => p.ExtraProperties);
        }
    }
}
