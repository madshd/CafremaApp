namespace CafremaApp.Application.DTOs.CommentInfo.Room;

public record CreateRoomDTO
{
    public string Title { get; init; } =  string.Empty;
}