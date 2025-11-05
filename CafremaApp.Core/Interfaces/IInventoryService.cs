using CafremaApp.Core.Entities;

namespace CafremaApp.Core.Interfaces;

public interface IInventoryService
{
    //Diverse usecases beskrives herunder
    Task<List<Inventory>> GetAllAsync();
    Task<Inventory?> GetInventoryItem(int id);
    Task CreateInventoryItem(Inventory inventory);
    Task UpdateInventoryItem(Inventory inventory);
    Task DeleteInventoryItem(Inventory inventory);
}