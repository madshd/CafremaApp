namespace CafremaApp.Application.DTOs.Room;

public class RoomDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<InventoryDTO> inventory = new List<InventoryDTO>();
    public List<ApplianceDTO> appliances = new List<ApplianceDTO>();
}