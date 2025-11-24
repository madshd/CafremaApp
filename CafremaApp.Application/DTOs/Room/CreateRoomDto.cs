namespace CafremaApp.Application.DTOs.CommentInfo.Room;

public record CreateRoomDto
{
    public string Title { get; init; } =  string.Empty;
}