using AutoMapper;
using CafremaApp.Application.DTOs.Room;
using CafremaApp.Application.Interfaces;
using CafremaApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafremaApp.WebAPI.Controllers;

    
[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;

    public RoomController(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _roomService.GetAllRooms();
        return Ok(rooms);
    }

    [HttpGet]
    [Route("GetRoomById")]
    public async Task<IActionResult> GetRoomById(Guid id)
    {
        var room = await _roomService.GetRoom(id);
        return Ok(room);
    }

    [HttpDelete]
    [Route("DeleteRoom")]
    public async Task<IActionResult> DeleteRoom(Guid id)
    {
        var deleted = await _roomService.DeleteRoom(id);

        if (deleted == null)
            return NotFound();

        return Ok(deleted);
    }

    [HttpPost]
    [Route("CreateRoom")]
    public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDTO room)
    {
        await _roomService.CreateRoom(room);
        return Ok();
    }
}