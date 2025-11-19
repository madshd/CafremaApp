using CafremaApp.Application.DTOs.Room;

namespace CafremaApp.Application.Interfaces;

public interface IRoomService
{
    Task<List<RoomDTO>> GetAllRooms();
    Task<RoomDTO?> GetRoom(Guid id);
    Task CreateRoom(CreateRoomDTO room);
    Task<RoomDTO>  UpdateRoom(RoomDTO room);
    Task<RoomDTO?>  DeleteRoom(Guid id);
}