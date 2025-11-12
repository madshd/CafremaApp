using CafremaApp.Core.Entities;

namespace CafremaApp.Core.ValueObjects;

public class CommentInfo
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime LastEdited { get; set; }
    public Inventory Inventory { get; set; }
    public Guid InventoryId { get; set; }

    public CommentInfo()
    {
    }

    public CommentInfo(string text, DateTime lastEdited)
    {
        Text = text;
        LastEdited = lastEdited;
    }
}