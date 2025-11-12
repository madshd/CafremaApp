using CafremaApp.Application.DTOs;
using CafremaApp.Core.Entities;

namespace CafremaApp.Core.Interfaces;

public interface IInventoryService
{
    //Diverse usecases beskrives herunder
    Task<List<InventoryDTO>> GetAllInventory();
    Task<InventoryDTO?> GetInventoryItem(Guid id);
    Task CreateInventoryItem(CreateInventoryDTO inventory);
    Task<InventoryDTO>  UpdateInventoryItem(InventoryDTO inventory);
    Task<InventoryDTO>  DeleteInventoryItem(InventoryDTO inventory);
}