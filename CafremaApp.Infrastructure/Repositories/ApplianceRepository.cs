using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;
using CafremaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CafremaApp.Infrastructure.Repositories;

public class ApplianceRepository :  IGenericRepository<Appliance>
{
    private readonly Context _dbContext;

    public ApplianceRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Appliance>> GetAllAsync()
    {
        return await _dbContext.Appliances
            .Include(i => i.CommentInfo)
            .ToListAsync();    
    }

    public async Task<Appliance?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Appliances.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Appliance> CreateAsync(Appliance entity)
    {
        _dbContext.Appliances.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Appliance> UpdateAsync(Appliance entity)
    {
        _dbContext.Appliances.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Appliance?> DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Appliances.FindAsync(id);

        if (entity == null)
            return null; 

        _dbContext.Appliances.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}