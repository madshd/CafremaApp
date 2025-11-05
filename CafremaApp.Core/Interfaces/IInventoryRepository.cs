using CafremaApp.Domain.Entities;

namespace CafremaApp.Domain.Interfaces;

public interface IInventoryRepository
{
    Task<Inventory?> GetByIdAsync(Guid id);
    Task AddAsync(Inventory inventory);
    Task UpdateAsync(Inventory inventory);
    Task DeleteAsync(Guid id);
}