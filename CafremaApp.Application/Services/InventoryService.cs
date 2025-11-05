using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IGenericRepository<Inventory> _repository;

    public InventoryService(IGenericRepository<Inventory> repository)
    {
        _repository = repository;
    }

    public async Task<List<Inventory>> GetAllInventory()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Inventory?> GetInventoryItem(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task CreateInventoryItem(Inventory inventory)
    {
        await _repository.CreateAsync(inventory);
    }

    public async Task<Inventory> UpdateInventoryItem(Inventory inventory)
    {
        return await _repository.UpdateAsync(inventory);
    }

    public async Task<Inventory> DeleteInventoryItem(Inventory inventory)
    {
        return await _repository.DeleteAsync(inventory);
    }
}