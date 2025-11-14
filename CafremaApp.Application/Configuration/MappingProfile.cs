using AutoMapper;
using CafremaApp.Application.DTOs;
using CafremaApp.Application.DTOs.Appliance;
using CafremaApp.Core.Entities;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Application.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Inventory
        CreateMap<Inventory, InventoryDTO>();
        CreateMap<InventoryDTO, Inventory>();
        CreateMap<CreateInventoryDTO, Inventory>();
        
        //Appliance
        CreateMap<Appliance, ApplianceDTO>();
        CreateMap<ApplianceDTO, Appliance>();
        CreateMap<CreateApplianceDTO, Appliance>();

        // CommentInfo
        CreateMap<CommentInfo, CommentInfoDTO>();
        CreateMap<CommentInfoDTO, CommentInfo>();
        CreateMap<CreateCommentInfoDTO, CommentInfo>()
            .ForMember(dest => dest.Inventory, opt => opt.Ignore())
            .ForMember(dest => dest.InventoryId, opt => opt.Ignore());
    }
}