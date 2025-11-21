using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs.CommentInfo;

public record class CreateApplianceDTO : CreateInventoryDTO
{
    public string Manufacturer { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
}