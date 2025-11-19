using CafremaApp.Application.DTOs;
using CafremaApp.Core.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace CafremaApp.Core.Interfaces;

public interface IInventoryService
{
    //Diverse usecases beskrives herunder
    Task<List<InventoryDTO>> GetAllInventory();
    Task<InventoryDTO?> GetInventoryItem(Guid id);
    Task CreateInventoryItem(CreateInventoryDTO inventory);
    Task<InventoryDTO>  UpdateInventoryItem(InventoryDTO inventory);
    Task<InventoryDTO?>  DeleteInventoryItem(Guid id);

    Task<bool> PatchInventory(Guid id, JsonPatchDocument<InventoryDTO> patchDoc);
}