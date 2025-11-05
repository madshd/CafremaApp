using CafremaApp.Domain.Enums;
using CafremaApp.Domain.ValueObjects;

namespace CafremaApp.Domain.Entities;

public class Inventory
{
    private Guid _guid = Guid.NewGuid();
    private string Type { get; set; }
    private DateOnly InstallationDate { get; set; }
    private Condition Condition { get; set; }
    private bool NeedsRepair { get; set; }
    private CommentInfo Comment { get; set; }

    public Inventory(string type, Condition condition)
    {
        Type = type;
        Condition = condition;
        Comment = new CommentInfo("", DateTime.Now);
        NeedsRepair = false;
    }
}

public class Appliance : Inventory
{
    private string Manufacturer { get; set; }
    private string Model { get; set; }

    public Appliance(string type, Condition condition, 
        string manufacturer, string model) : base(type, condition)
    {
        Manufacturer = manufacturer;
        Model = model;
    }
}