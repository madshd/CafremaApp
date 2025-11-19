using AutoMapper;
using CafremaApp.Application.DTOs;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;
namespace CafremaApp.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IGenericRepository<Inventory> _repository;
    private readonly IMapper _mapper;

    public InventoryService(IGenericRepository<Inventory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<InventoryDTO>> GetAllInventory()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = _mapper.Map<List<InventoryDTO>>(list);
        return dtoList;
    }

    public async Task<InventoryDTO?> GetInventoryItem(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<InventoryDTO>(entity);
    }


    public async Task CreateInventoryItem(CreateInventoryDTO inventory)
    {
        await _repository.CreateAsync(_mapper.Map<Inventory>(inventory));
    }

    public async Task<InventoryDTO> UpdateInventoryItem(InventoryDTO inventory)
    {
        var updatedEntity = await _repository.UpdateAsync(_mapper.Map<Inventory>(inventory));
        return _mapper.Map<InventoryDTO>(updatedEntity);
    }

    public async Task<InventoryDTO?> DeleteInventoryItem(Guid id)
    {
        var deletedEntity = await _repository.DeleteAsync(id);

        if (deletedEntity == null)
            return null;

        return _mapper.Map<InventoryDTO>(deletedEntity);
    }
}