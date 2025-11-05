using CafremaApp.Core.Entities;
using CafremaApp.Core;
using CafremaApp.Core.Interfaces;
using CafremaApp.Infrastructure.Data;

namespace CafremaApp.Infrastructure.Repositories;

public class InventoryRepository :  IGenericRepository<Inventory>
{
    private readonly Context _dbContext; 
    public InventoryRepository(Context dbContext) { _dbContext = dbContext; }
    
    public Task<List<Inventory>> GetAllAsync()
    {
        var list = _dbContext.Inventories.ToList();
        return Task.FromResult(list);
    }

    public Task<Inventory?> GetByIdAsync(int id)
    {
        var item = _dbContext.Inventories.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(item);
    }

    public Task<Inventory> CreateAsync(Inventory entity)
    {
        _dbContext.Inventories.Add(entity);
        _dbContext.SaveChanges();
        return Task.FromResult(entity);
    }

    public Task<Inventory> UpdateAsync(Inventory entity)
    {
        _dbContext.Inventories.Update(entity);
        _dbContext.SaveChanges();
        return Task.FromResult(entity);
    }

    public Task<Inventory> DeleteAsync(Inventory inventory)
    {
        _dbContext.Inventories.Remove(inventory);
        _dbContext.SaveChanges();
        return Task.FromResult(inventory);
    }
}