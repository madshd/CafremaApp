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
    public Guid? RoomId { get; set; }
    public Room? Room { get; set; }
    public Inventory()
    {
    }

    public Inventory(string type, Condition condition)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        if (string.IsNullOrWhiteSpace(type))
        {
            throw new ArgumentException(
                "Type must not be empty.", nameof(type));
        }
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
        ArgumentNullException.ThrowIfNull(manufacturer);
        if (string.IsNullOrWhiteSpace(manufacturer))
        {
            throw new ArgumentException(
                "Manufacturer must not be empty.", nameof(manufacturer));
        }

        ArgumentNullException.ThrowIfNull(model);
        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException(
                "Model must not be empty.", nameof(model));
        }
        
        Manufacturer = manufacturer;
        Model = model;
    }
}