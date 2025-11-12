using AutoMapper;
using CafremaApp.Application.DTOs;
using CafremaApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Enums;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventory()
        {
            var inventory = await _inventoryService.GetAllInventory();
            return Ok(inventory);
        }

        [HttpGet]
        [Route("GetInventoryById")]
        public async  Task<IActionResult> GetInventoryById(Guid id)
        {
            var inventory = await _inventoryService.GetInventoryItem(id);
            return Ok(inventory);
        }

        [HttpDelete]
        [Route("DeleteInventory")]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            
            var inventory = await _inventoryService.GetInventoryItem(id);
            return inventory == null ? NotFound() : Ok(await _inventoryService.DeleteInventoryItem(inventory));
        }
        
        [HttpPost]
        [Route("CreateInventory")]
        public async Task<IActionResult> CreateInventory([FromBody] InventoryDTO inventory)
        {
            await _inventoryService.CreateInventoryItem(inventory);
            return Ok();
        }

        //TODO Den her skal vel have nogle flere arguments?
        //TODO Kan jeg bare smide et nyt objekt ind med den samme iD og saa er alt godt????
        [HttpPut]
        [Route("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory([FromBody] InventoryDTO inventory)
        {
            await _inventoryService.UpdateInventoryItem(inventory);
            return Ok();
        }

    }
}