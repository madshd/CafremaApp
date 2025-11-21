namespace CafremaApp.Application.DTOs.CommentInfo;

public record CommentInfoDTO
{
    public Guid Id { get; init; }
    public string Text { get; init; } = string.Empty;
    public DateTime LastEdited { get; init; }
    public Guid InventoryId { get; init; }
}