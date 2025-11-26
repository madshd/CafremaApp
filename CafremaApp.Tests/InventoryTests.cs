using CafremaApp.Core.Entities;
using CafremaApp.Core.Enums;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Tests;

[TestFixture]
public class InventoryTests
{
    [Test]
    public void Inventory_Constructor_SetsPropertiesCorrectly()
    {
        var type = "TestType";
        var condition = Condition.God;
        
        var inventory = new Inventory(type, condition);

        Assert.That(inventory.Type, Is.EqualTo(type));
        Assert.That(inventory.Condition, Is.EqualTo(condition));
        Assert.That(inventory.NeedsRepair, Is.False);
        Assert.That(inventory.CommentInfo, Is.Null);
        Assert.That(inventory.Id, Is.EqualTo(Guid.Empty));
        Assert.That(inventory.InstallationDate, Is.EqualTo(default(DateOnly)));
    }

    [Test]
    public void Appliance_Constructor_SetsPropertiesCorrectly()
    {
        var type = "TestType";
        var condition = Condition.Slidt;
        var manufacturer = "TestManufacturer";
        var model = "TestModel";

        var appliance = new Appliance(type, condition, manufacturer, model);

        Assert.That(appliance.Type, Is.EqualTo(type));
        Assert.That(appliance.Condition, Is.EqualTo(condition));
        Assert.That(appliance.NeedsRepair, Is.False);
        Assert.That(appliance.CommentInfo, Is.Null);
        Assert.That(appliance.Id, Is.EqualTo(Guid.Empty));
        Assert.That(appliance.InstallationDate, Is.EqualTo(default(DateOnly)));
        Assert.That(appliance.Manufacturer, Is.EqualTo(manufacturer));
        Assert.That(appliance.Model, Is.EqualTo(model));
    }

    [Test]
    public void Inventory_Properties_CanBeSetAndGot()
    {
        var inventory = new Inventory("TestType", Condition.Dårlig);
        var newId = Guid.NewGuid();
        var newDate = new DateOnly(2025, 11, 14);
        var commentText = "TestComment";
        var lastEdited = DateTime.Now;
        var commentInfo = new CommentInfo(commentText, lastEdited)
        {
            Id = Guid.NewGuid(),
            InventoryId = newId
        };
        
        inventory.Id = newId;
        inventory.InstallationDate = newDate;
        inventory.NeedsRepair = true;
        inventory.CommentInfo = commentInfo;
        
        Assert.That(inventory.Id, Is.EqualTo(newId));
        Assert.That(inventory.InstallationDate, Is.EqualTo(newDate));
        Assert.That(inventory.NeedsRepair, Is.True);
        Assert.That(inventory.CommentInfo, Is.Not.Null);
        Assert.That(inventory.CommentInfo.Text, Is.EqualTo(commentText));
        Assert.That(inventory.CommentInfo.LastEdited, Is.EqualTo(lastEdited));
        Assert.That(inventory.CommentInfo.InventoryId, Is.EqualTo(newId));
    }
    
    [Test]
    public void Appliance_Properties_CanBeSetAndGot()
    {
        var appliance = new Appliance(
            "TestType", Condition.ForefindesIkke, "Manufacturer", "Model");
        var newId = Guid.NewGuid();
        var newDate = new DateOnly(2025, 11, 14);
        var commentText = "Test comment";
        var lastEdited = DateTime.Now;
        var commentInfo = new CommentInfo(commentText, lastEdited)
        {
            Id = Guid.NewGuid(),
            InventoryId = newId
        };

        appliance.Id = newId;
        appliance.InstallationDate = newDate;
        appliance.NeedsRepair = true;
        appliance.CommentInfo = commentInfo;
        
        Assert.That(appliance.Id, Is.EqualTo(newId));
        Assert.That(appliance.InstallationDate, Is.EqualTo(newDate));
        Assert.That(appliance.NeedsRepair, Is.True);
        Assert.That(appliance.CommentInfo, Is.Not.Null);
        Assert.That(appliance.CommentInfo.Text, Is.EqualTo(commentText));
        Assert.That(appliance.CommentInfo.LastEdited, Is.EqualTo(lastEdited));
        Assert.That(appliance.CommentInfo.InventoryId, Is.EqualTo(newId));
        Assert.That(appliance.Manufacturer, Is.EqualTo("Manufacturer"));
        Assert.That(appliance.Model, Is.EqualTo("Model"));
    }
    
    // ------------------------------------------------------------------------------
    
    [Test]
    public void Inventory_Constructor_ThrowsOnNullType()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Inventory(null, Condition.God));
    }
    
    [Test]
    public void Inventory_Constructor_ThrowsOnEmptyType()
    {
        Assert.Throws<ArgumentException>(() =>
            new Inventory("", Condition.God));
    }

    [Test]
    public void Appliance_Constructor_ThrowsOnNullManufacturer()
    {
        Assert.Throws<ArgumentNullException>(() => 
            new Appliance("TestOvn", Condition.God, null, "TestModel"));
    }

    [Test]
    public void Appliance_Constructor_ThrowsOnEmptyManufacturer()
    {
        Assert.Throws<ArgumentException>(() =>
            new Appliance("TestOvn", Condition.God, "", "TestModel"));
    }

    [Test]
    public void Appliance_Constructor_ThrowsOnNullModel()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new Appliance("TestOvn", Condition.God, "TestManufacturer", null));
    }

    [Test]
    public void Appliance_Constructor_ThrowsOnEmptyModel()
    {
        Assert.Throws<ArgumentException>(() =>
            new Appliance("TestOvn", Condition.God, "TestManufacturer", ""));
    }
}