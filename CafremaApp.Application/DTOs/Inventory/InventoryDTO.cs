using CafremaApp.Core.Enums;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Application.DTOs;

public class InventoryDTO
{
    
    public Guid Id { get; set; }
    public string Type { get; set; }
    public DateOnly InstallationDate { get; set; }
    public Condition Condition { get; set; }
    public bool NeedsRepair { get; set; }
    public CommentInfoDTO? CommentInfo { get; set; }
    //public Guid? CommentInfoId { get; set; }

    public InventoryDTO() { }

    public InventoryDTO(string type, Condition condition)
    {
        Type = type;
        Condition = condition;
        NeedsRepair = false;
    }
    
}

public class ApplianceDTO : InventoryDTO
{
    
    public string Manufacturer { get; set; }
    
    public string Model { get; set; }

}