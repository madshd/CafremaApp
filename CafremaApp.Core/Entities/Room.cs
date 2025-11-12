using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Core.Entities;

public class Room
{
    public Guid _guid = Guid.NewGuid();
    public string Title { get; set; }
    public List<Inventory> inventory = new List<Inventory>();
    public List<Appliance> appliances = new List<Appliance>();
}