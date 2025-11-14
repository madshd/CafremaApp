using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs.Appliance;

public class CreateApplianceDTO : CreateInventoryDTO
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
}