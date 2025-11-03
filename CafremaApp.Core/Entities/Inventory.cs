using CafremaApp.Domain.Enums;

namespace CafremaApp.Domain.Entities;

public class Inventory
{
    private string Id { get; set; }
    private string Type { get; set; }
    private DateOnly InstallationDate { get; set; }
    private Condition Condition { get; set; }
    private string Comment { get; set; }

    public Inventory(string id, string type, DateOnly installationDate, Condition condition, string comment)
    {
        Id = id;
        Type = type;
        InstallationDate = installationDate;
        Condition = condition;
        Comment = comment;
    }
}

public class Appliance : Inventory
{
    private string Manufacturer { get; set; }
    private string Model { get; set; }

    public Appliance(string id, string type, DateOnly installationDate, Condition condition, string comment, 
        string manufacturer, string model) : base(id, type, installationDate, condition, comment)
    {
        Manufacturer = manufacturer;
        Model = model;
    }
}