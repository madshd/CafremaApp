namespace CafremaApp.Application.DTOs;

public class CommentInfoDTO
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime LastEdited { get; set; }
    public Guid InventoryId { get; set; }
}