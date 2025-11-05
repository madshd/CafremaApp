using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.Infrastructure.Repositories;

public class InventoryRepository :  IInventoryRepository
{
    public Task<Inventory?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}