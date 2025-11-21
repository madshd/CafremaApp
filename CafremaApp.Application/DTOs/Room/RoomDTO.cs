using CafremaApp.Application.DTOs.CommentInfo;

public record class RoomDTO
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;

    public List<InventoryDTO> Inventory { get; init; } = new();
    public List<ApplianceDTO> Appliances { get; init; } = new();
}