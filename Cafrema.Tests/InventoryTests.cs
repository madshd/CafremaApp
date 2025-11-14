using CafremaApp.Core.Entities;
using CafremaApp.Core.Enums;
using CafremaApp.Core.ValueObjects;

namespace Cafrema.Tests;

[TestFixture]
public class InventoryTests
{
    [Test]
    public void Inventory_Constructor_SetsPropertiesCorrectly()
    {
        var type = "TestType";
        var condition = Condition.God;
        
        var inventory = new Inventory(type, condition);

        Assert.AreEqual(type, inventory.Type);
        Assert.AreEqual(condition, inventory.Condition);
        Assert.IsFalse(inventory.NeedsRepair);
        Assert.IsNull(inventory.CommentInfo);
        Assert.AreEqual(default(Guid), inventory.Id);
        Assert.AreEqual(default(DateOnly), inventory.InstallationDate);
    }

    [Test]
    public void Appliance_Constructor_SetsPropertiesCorrectly()
    {
        var type = "TestType";
        var condition = Condition.Slidt;
        var manufacturer = "TestManufacturer";
        var model = "TestModel";

        var appliance = new Applicance(type, condition, manufacturer, model);

        Assert.AreEqual(type, appliance.Type);
        Assert.AreEqual(condition, appliance.Condition);
        Assert.IsFalse(appliance.NeedsRepair);
        Assert.IsNull(appliance.CommentInfo);
        Assert.AreEqual(default(Guid), appliance.Id);
        Assert.AreEqual(default(DateOnly), appliance.InstallationDate);
        Assert.AreEqual(manufacturer, appliance.Manufacturer);
        Assert.AreEqual(model, appliance.Model);
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
        
        Assert.AreEqual(newId, inventory.Id);
        Assert.AreEqual(newDate, inventory.InstallationDate);
        Assert.IsTrue(inventory.NeedsRepair);
        Assert.IsNotNull(inventory.CommentInfo);
        Assert.AreEqual(commentText, inventory.CommentInfo.Text);
        Assert.AreEqual(lastEdited, inventory.CommentInfo.LastEdited);
        Assert.AreEqual(newId, inventory.CommentInfo.InventoryId);
    }
    
    [Test]
    public void Appliance_Properties_CanBeSetAndGot()
    {
        var appliance = new Appliance("TestType", Condition.ForefindesIkke, "Manufacturer", "Model");
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

        Assert.AreEqual(newId, appliance.Id);
        Assert.AreEqual(newDate, appliance.InstallationDate);
        Assert.IsTrue(appliance.NeedsRepair);
        Assert.IsNotNull(appliance.CommentInfo);
        Assert.AreEqual(commentText, appliance.CommentInfo.Text);
        Assert.AreEqual(lastEdited, appliance.CommentInfo.LastEdited);
        Assert.AreEqual(newId, appliance.CommentInfo.InventoryId);
        Assert.AreEqual("Manufacturer", appliance.Manufacturer);
        Assert.AreEqual("Model", appliance.Model);
    }
}