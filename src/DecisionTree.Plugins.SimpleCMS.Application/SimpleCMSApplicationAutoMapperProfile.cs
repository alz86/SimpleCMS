using AutoMapper;
using DecisionTree.Plugins.SimpleCMS.Dto;
using DecisionTree.Plugins.SimpleCMS.Entities;
using Volo.Abp.AutoMapper;

namespace DecisionTree.Plugins.SimpleCMS.Application;

public class SimpleCMSApplicationAutoMapperProfile : Profile
{
    public SimpleCMSApplicationAutoMapperProfile()
    {
        CreateMap<ContentEntry, ContentEntryDto>();
        CreateMap<CreateUpdateContentEntryDto, ContentEntry>()
            .IgnoreAuditedObjectProperties()
            .ForMember(x => x.ExtraProperties, x => x.Ignore())
            .ForMember(x => x.ConcurrencyStamp, x => x.Ignore());
    }
}
