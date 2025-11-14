using CafremaApp.Application.DTOs.Room;

namespace CafremaApp.Core.Interfaces;

public interface IRoomService
{
    Task<List<RoomDTO>> GetAllRooms();
    Task<RoomDTO?> GetRoom(Guid id);
    Task CreateRoom(CreateRoomDTO room);
    Task<RoomDTO>  UpdateRoom(RoomDTO room);
    Task<RoomDTO>  DeleteRoom(RoomDTO room);
}