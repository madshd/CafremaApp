using CafremaApp.Application.DTOs.Inventory;
// using Microsoft.AspNetCore.JsonPatch;

namespace CafremaApp.Application.Interfaces;

public interface IInventoryService
{
    //Diverse usecases beskrives herunder
    Task<List<InventoryDto>> GetAllInventory();
    Task<InventoryDto?> GetInventoryItem(Guid id);
    Task CreateInventoryItem(CreateInventoryDto inventory);
    Task<InventoryDto>  UpdateInventoryItem(InventoryDto inventory);
    Task<InventoryDto?>  DeleteInventoryItem(Guid id);

    // Task<bool> PatchInventory(Guid id, JsonPatchDocument<InventoryDto> patchDoc);
}