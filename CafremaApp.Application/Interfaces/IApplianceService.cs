using CafremaApp.Application.DTOs.Appliance;

namespace CafremaApp.Application.Interfaces;

public interface IApplianceService
{
    //Diverse usecases beskrives herunder
    Task<List<ApplianceDTO>> GetAllAppliances();
    Task<ApplianceDTO?> GetApplianceItem(Guid id);
    Task CreateApplianceItem(CreateApplianceDTO appliance);
    Task<ApplianceDTO>  UpdateApplianceItem(ApplianceDTO appliance);
    Task<ApplianceDTO>  DeleteApplianceItem(Guid id);
    
}
