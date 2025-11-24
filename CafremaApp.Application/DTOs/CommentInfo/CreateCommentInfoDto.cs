namespace CafremaApp.Application.DTOs.CommentInfo;

public record CreateCommentInfoDto
{
    public string Text { get; init; } = string.Empty;
    public DateTime LastEdited { get; init; }
}