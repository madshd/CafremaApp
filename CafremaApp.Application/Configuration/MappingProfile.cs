using AutoMapper;
using CafremaApp.Application.DTOs;
using CafremaApp.Core.Entities;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Application.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Inventory, InventoryDTO>();
        CreateMap<InventoryDTO, Inventory>();
        CreateMap<CommentInfo, CommentInfoDTO>();
    }
    
}