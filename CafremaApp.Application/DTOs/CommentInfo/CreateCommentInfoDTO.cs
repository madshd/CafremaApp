namespace CafremaApp.Application.DTOs.CommentInfo;

public record CreateCommentInfoDTO
{
    public string Text { get; init; } = string.Empty;
    public DateTime LastEdited { get; init; }
}