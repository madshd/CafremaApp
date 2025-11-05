using CafremaApp.Core.Entities;
using CafremaApp.Core;
using CafremaApp.Core.Interfaces;
using CafremaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CafremaApp.Infrastructure.Repositories;

public class InventoryRepository :  IGenericRepository<Inventory>
{
    private readonly Context _dbContext; 
    public InventoryRepository(Context dbContext) { _dbContext = dbContext; }
    
    public async Task<List<Inventory>> GetAllAsync()
    {
        return await _dbContext.Inventories.ToListAsync();
    }

    public async Task<Inventory?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Inventories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Inventory> CreateAsync(Inventory entity)
    {
        _dbContext.Inventories.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Inventory> UpdateAsync(Inventory entity)
    {
        _dbContext.Inventories.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Inventory> DeleteAsync(Inventory inventory)
    {
        _dbContext.Inventories.Remove(inventory);
        await _dbContext.SaveChangesAsync();
        return inventory;
    }
}