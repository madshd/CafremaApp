using CafremaApp.Application.DTOs.Appliance;

namespace CafremaApp.Application.Interfaces;

public interface IApplianceService
{
    //Diverse usecases beskrives herunder
    Task<List<ApplianceDto>> GetAllAppliances();
    Task<ApplianceDto?> GetApplianceItem(Guid id);
    Task CreateApplianceItem(CreateApplianceDto appliance);
    Task<ApplianceDto>  UpdateApplianceItem(ApplianceDto appliance);
    Task<ApplianceDto>  DeleteApplianceItem(Guid id);
    
}
