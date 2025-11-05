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

    public Inventory(string type, Condition condition, CommentInfo comment)
    {
        Type = type;
        Condition = condition;
        Comment = comment;
        NeedsRepair = false;
    }
}

public class Appliance : Inventory
{
    private string Manufacturer { get; set; }
    private string Model { get; set; }

    public Appliance(string type, Condition condition, CommentInfo comment, 
        string manufacturer, string model) : base(type, condition, comment)
    {
        Manufacturer = manufacturer;
        Model = model;
    }
}