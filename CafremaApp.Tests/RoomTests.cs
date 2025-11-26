using CafremaApp.Core.Entities;
using CafremaApp.Core.Enums;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Tests;

[TestFixture]
public class RoomTests
{
    [Test]
    public void Room_Initialization_ShouldSetDefaultValues()
    {
        var room = new Room();
        
        Assert.That(room.Id, Is.EqualTo(Guid.Empty));
        Assert.That(room.Title, Is.Null);
        Assert.That(room.Inventory, Is.Not.Null);
        Assert.That(room.Inventory, Is.Empty);
    }

    [Test]
    public void Room_PropertyAssignment_ShouldWork()
    {
        var room = new Room();
        var id = Guid.NewGuid();
        var title = "Meeting Room";

        room.Id = id;
        room.Title = title;

        Assert.That(room.Id, Is.EqualTo(id));
        Assert.That(room.Title, Is.EqualTo(title));
    }
    
    [Test]
    public void Room_AddInventoryItem_ShouldAddItem()
    {
        var room = new Room();
        var inventoryItem = new Inventory("Væg", Condition.God);

        room.Inventory.Add(inventoryItem);

        Assert.That(room.Inventory.Count, Is.EqualTo(1));
        Assert.That(room.Inventory[0], Is.EqualTo(inventoryItem));
    }

    [Test]
    public void Room_RemoveInventoryItem_ShouldRemoveItem()
    {
        var room = new Room();
        var inventoryItem = new Inventory("Væg", Condition.God);
        room.Inventory.Add(inventoryItem);

        room.Inventory.Remove(inventoryItem);

        Assert.That(room.Inventory, Is.Empty);
    }

    [Test]
    public void Room_Inventory_ShouldNeverBeNull()
    {
        var room = new Room();

        Assert.That(room.Inventory, Is.Not.Null);
    }
    
    [Test]
    public void Room_AddAppliance_ShouldAddAppliance()
    {
        var room = new Room();
        var appliance = new Appliance(
            "Køleskab", Condition.God, "Manufacturer", "Model");

        room.Inventory.Add(appliance);

        Assert.That(room.Inventory.Count, Is.EqualTo(1));
        Assert.That(room.Inventory[0], Is.EqualTo(appliance));
    }

    [Test]
    public void Room_AddInventoryWithComment_ShouldAddItemWithComment()
    {
        var room = new Room();
        var inventoryItem = new Inventory("Stol", Condition.God);
        inventoryItem.CommentInfo = new CommentInfo("Ny pude", DateTime.Now);

        room.Inventory.Add(inventoryItem);

        Assert.That(room.Inventory.Count, Is.EqualTo(1));
        Assert.That(room.Inventory[0].CommentInfo, Is.Not.Null);
        Assert.That(room.Inventory[0].CommentInfo.Text, Is.EqualTo("Ny pude"));
    }
    
    [Test]
    public void Room_InventoryItemProperties_ShouldBeCorrect()
    {
        var room = new Room();
        var inventoryItem = new Inventory("Stol", Condition.God)
        {
            InstallationDate = new DateOnly(2025, 1, 1),
            NeedsRepair = true
        };

        room.Inventory.Add(inventoryItem);

        Assert.That(room.Inventory[0].Type, Is.EqualTo("Stol"));
        Assert.That(room.Inventory[0].Condition, Is.EqualTo(Condition.God));
        Assert.That(room.Inventory[0].InstallationDate,
            Is.EqualTo(new DateOnly(2025, 1, 1)));
        Assert.That(room.Inventory[0].NeedsRepair, Is.True);
    }
}