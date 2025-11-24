using AutoMapper;
using CafremaApp.Application.DTOs;
using CafremaApp.Application.DTOs.Inventory;
using CafremaApp.Application.Interfaces;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

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

    public async Task<List<InventoryDto>> GetAllInventory()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = _mapper.Map<List<InventoryDto>>(list);
        return dtoList;
    }

    public async Task<InventoryDto?> GetInventoryItem(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<InventoryDto>(entity);
    }


    public async Task CreateInventoryItem(CreateInventoryDto inventory)
    {
        await _repository.CreateAsync(_mapper.Map<Inventory>(inventory));
    }

    public async Task<InventoryDto> UpdateInventoryItem(InventoryDto inventory)
    {
        var updatedEntity = await _repository.UpdateAsync(_mapper.Map<Inventory>(inventory));
        return _mapper.Map<InventoryDto>(updatedEntity);
    }

    public async Task<InventoryDto?> DeleteInventoryItem(Guid id)
    {
        var deletedEntity = await _repository.DeleteAsync(id);

        if (deletedEntity == null)
            return null;

        return _mapper.Map<InventoryDto>(deletedEntity);
    }

    public async Task<bool> PatchInventory(Guid id, JsonPatchDocument<InventoryDto> patchDoc)
    {
        var inventory = await _repository.GetByIdAsync(id);
        if (inventory == null) return false;

        var dto = _mapper.Map<InventoryDto>(inventory);
        
        patchDoc.ApplyTo(dto);

        _mapper.Map<Inventory>(dto);

        await _repository.SaveChangesAsync();
        return true;
    }
}