namespace CafremaApp.Infrastructure.Repositories;

public interface IInventoryRepository
{
    Task<Inventory?> GetByIdAsync(Guid id);
    Task AddAsync(Inventory inventory);
    Task UpdateAsync(Inventory inventory);
    Task DeleteAsync(Guid id);
}