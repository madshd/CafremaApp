using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Application.DTOs.Inventory;

namespace CafremaApp.Application.DTOs.Appliance;

public record ApplianceDto : InventoryDto
{
    public string Manufacturer { get; init; } = string.Empty;
    public string Model { get; init; } = string.Empty;
}