using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs.Appliance;

public class ApplianceDTO : InventoryDTO
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
}