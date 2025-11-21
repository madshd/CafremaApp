using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs.CommentInfo;

public record class ApplianceDTO : InventoryDTO
{
    public string Manufacturer { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
}