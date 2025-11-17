using AutoMapper;
using CafremaApp.Application.DTOs;
using CafremaApp.Application.DTOs.Appliance;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.Application.Services;

public class ApplianceService : IApplianceService
{
    private readonly IGenericRepository<Inventory> _repository;
    private readonly IMapper _mapper;

    public ApplianceService(IGenericRepository<Inventory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ApplianceDTO>> GetAllAppliances()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = _mapper.Map<List<ApplianceDTO>>(list);
        return dtoList;
    }

    public async Task<ApplianceDTO?> GetApplianceItem(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ApplianceDTO>(entity);
    }


    public async Task CreateApplianceItem(CreateApplianceDTO appliance)
    {
        await _repository.CreateAsync(_mapper.Map<Appliance>(appliance));
    }

    public async Task<ApplianceDTO> UpdateApplianceItem(ApplianceDTO appliance)
    {
        var updatedEntity = await _repository.UpdateAsync(_mapper.Map<Appliance>(appliance));
        return _mapper.Map<ApplianceDTO>(updatedEntity);
    }

    public async Task<ApplianceDTO> DeleteApplianceItem(ApplianceDTO appliance)
    {
        
        var deletedEntity = await _repository.DeleteAsync(_mapper.Map<Appliance>(appliance));
        return _mapper.Map<ApplianceDTO>(deletedEntity);
    }
}
