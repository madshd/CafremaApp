using CafremaApp.Application.DTOs.CommentInfo.Room;
using CafremaApp.Application.DTOs.Room;

namespace CafremaApp.Application.Interfaces;

public interface IRoomService
{
    Task<List<RoomDto>> GetAllRooms();
    Task<RoomDto?> GetRoom(Guid id);
    Task CreateRoom(CreateRoomDto room);
    Task<RoomDto>  UpdateRoom(RoomDto room);
    Task<RoomDto?>  DeleteRoom(Guid id);
}