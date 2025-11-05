using CafremaApp.Core.Entities;

namespace CafremaApp.Core.Interfaces;

public interface IInventoryService
{
    //Diverse usecases beskrives herunder
    Task<List<Inventory>> GetAllInventory();
    Task<Inventory?> GetInventoryItem(Guid id);
    Task CreateInventoryItem(Inventory inventory);
    Task<Inventory>  UpdateInventoryItem(Inventory inventory);
    Task<Inventory>  DeleteInventoryItem(Inventory inventory);
}