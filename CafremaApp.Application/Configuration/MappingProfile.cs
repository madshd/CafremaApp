using AutoMapper;
using CafremaApp.Application.DTOs;
using CafremaApp.Application.DTOs.Appliance;
using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Application.DTOs.CommentInfo.Room;
using CafremaApp.Application.DTOs.Inventory;
using CafremaApp.Application.DTOs.Room;
using CafremaApp.Core.Entities;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Application.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Inventory
        CreateMap<Inventory, InventoryDto>();
        CreateMap<InventoryDto, Inventory>();
        CreateMap<CreateInventoryDto, Inventory>();
        
        //Appliance
        CreateMap<Appliance, ApplianceDto>();
        CreateMap<ApplianceDto, Appliance>();
        CreateMap<CreateApplianceDto, Appliance>();

        // CommentInfo
        CreateMap<CommentInfo, CommentInfoDto>();
        CreateMap<CommentInfoDto, CommentInfo>();
        CreateMap<CreateCommentInfoDto, CommentInfo>()
            .ForMember(dest => dest.Inventory, opt => opt.Ignore())
            .ForMember(dest => dest.InventoryId, opt => opt.Ignore());
        
        // Room
        CreateMap<Room, RoomDto>();
        CreateMap<CreateRoomDto, Room>();
    }
}