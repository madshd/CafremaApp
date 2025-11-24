using CafremaApp.Application.DTOs.Appliance;
using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Application.DTOs.Inventory;

namespace CafremaApp.Application.DTOs.Room;
public record RoomDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;

    public List<InventoryDto> Inventory { get; init; } = new();
    public List<ApplianceDto> Appliances { get; init; } = new();
}