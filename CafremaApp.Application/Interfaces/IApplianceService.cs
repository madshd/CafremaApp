using CafremaApp.Application.DTOs.Appliance;

namespace CafremaApp.Core.Interfaces;

public interface IApplianceService
{
    //Diverse usecases beskrives herunder
    Task<List<ApplianceDTO>> GetAllAppliances();
    Task<ApplianceDTO?> GetApplianceItem(Guid id);
    Task CreateApplianceItem(CreateApplianceDTO appliance);
    Task<ApplianceDTO>  UpdateApplianceItem(ApplianceDTO appliance);
    Task<ApplianceDTO>  DeleteApplianceItem(ApplianceDTO appliance);
    
}
