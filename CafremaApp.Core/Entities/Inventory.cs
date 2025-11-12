using CafremaApp.Core.Enums;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Core.Entities;

public class Inventory
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public DateOnly InstallationDate { get; set; }
    public Condition Condition { get; set; }
    public bool NeedsRepair { get; set; }
    public CommentInfo? CommentInfo { get; set; }
    
    public Inventory(string type, Condition condition)
    {
        Type = type;
        Condition = condition;
        NeedsRepair = false;
    }
}

public class Appliance : Inventory
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }

    public Appliance(string type, Condition condition, 
        string manufacturer, string model) : base(type, condition)
    {
        Manufacturer = manufacturer;
        Model = model;
    }
}