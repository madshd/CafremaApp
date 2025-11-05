using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.Application.Services;

// TODO Mangler en DTO Mapper
public class InventoryService :  IInventoryService
{
    private readonly IGenericRepository<Inventory> _repository;

    public InventoryService(IGenericRepository<Inventory> repository)
    {
        _repository = repository;
    }

    public Task<List<Inventory>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Inventory?> GetInventoryItem(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task CreateInventoryItem(Inventory inventory)
    {
        return _repository.CreateAsync(inventory);
    }

    public Task UpdateInventoryItem(Inventory inventory)
    {
        return _repository.UpdateAsync(inventory);
    }

    public Task DeleteInventoryItem(Inventory inventory)
    {
        _repository.DeleteAsync(inventory);
        return Task.CompletedTask;
    }
}