using CafremaApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;

namespace CafremaApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
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
        public async Task<IActionResult> CreateInventory()
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateInventory(int id, string name, string description)
        { 
            //InventoryService.Put(id, name, description)
            return Ok();
        }

    }
}