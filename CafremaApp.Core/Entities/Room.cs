using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Core.Entities;

public class Room
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<Inventory> Inventory { get; set; } = [];
}