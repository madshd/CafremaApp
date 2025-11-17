using AutoMapper;
using CafremaApp.Application.DTOs.Room;
using CafremaApp.Application.Interfaces;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.Application.Services;

public class RoomService : IRoomService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Room> _repository;

    public RoomService(IMapper mapper, IGenericRepository<Room> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<RoomDTO>> GetAllRooms()
    {
        var list = await _repository.GetAllAsync();
        var dtoList = _mapper.Map<List<RoomDTO>>(list);
        return dtoList;
    }

    public async Task<RoomDTO?> GetRoom(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<RoomDTO>(entity);
    }

    public async Task CreateRoom(CreateRoomDTO room)
    {
        await _repository.CreateAsync(_mapper.Map<Room>(room));
    }

    public async Task<RoomDTO> UpdateRoom(RoomDTO room)
    {
        throw new NotImplementedException();
    }

    public async Task<RoomDTO?> DeleteRoom(Guid id)
    {
        var deletedEntity = await _repository.DeleteAsync(id);

        if (deletedEntity == null)
            return null;

        return _mapper.Map<RoomDTO>(deletedEntity);
    }
}