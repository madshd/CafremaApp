using AutoMapper;
using CafremaApp.Application.DTOs.Appliance;
using CafremaApp.Application.Interfaces;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.Application.Services;

public class ApplianceService : IApplianceService
{
    private readonly IGenericRepository<Appliance> _repository;
    private readonly IMapper _mapper;

    public ApplianceService(IGenericRepository<Appliance> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ApplianceDto>> GetAllAppliances()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = _mapper.Map<List<ApplianceDto>>(list);
        return dtoList;
    }

    public async Task<ApplianceDto?> GetApplianceItem(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ApplianceDto>(entity);
    }


    public async Task CreateApplianceItem(CreateApplianceDto appliance)
    {
        await _repository.CreateAsync(_mapper.Map<Appliance>(appliance));
    }

    public async Task<ApplianceDto> UpdateApplianceItem(ApplianceDto appliance)
    {
        var updatedEntity = await _repository.UpdateAsync(_mapper.Map<Appliance>(appliance));
        return _mapper.Map<ApplianceDto>(updatedEntity);
    }

    public async Task<ApplianceDto> DeleteApplianceItem(Guid id)
    {
        var deletedEntity = await _repository.DeleteAsync(id);

        if (deletedEntity == null)
            return null;

        return _mapper.Map<ApplianceDto>(deletedEntity);
    }
}
