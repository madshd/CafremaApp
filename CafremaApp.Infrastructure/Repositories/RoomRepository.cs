using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;
using CafremaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CafremaApp.Infrastructure.Repositories;

public class RoomRepository : IGenericRepository<Room>
{
    private readonly Context _dbContext;

    public RoomRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await _dbContext.Rooms
            .Include(i => i.Inventory)
            .ToListAsync();
    }

    public async Task<Room?> GetByIdAsync(Guid id)
    {
       return await _dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Room> CreateAsync(Room entity)
    {
        _dbContext.Rooms.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Room> UpdateAsync(Room entity)
    {
        _dbContext.Rooms.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<Room?> DeleteAsync(Guid id)
    {
        var entity = await _dbContext.Rooms.FindAsync(id);

        if (entity == null)
            return null; 

        _dbContext.Rooms.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}