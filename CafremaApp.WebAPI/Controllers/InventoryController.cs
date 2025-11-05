using Microsoft.AspNetCore.Mvc;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafremaApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service) 
        { 
            _service = service; 
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> GetAllInventory()
        {
            var inventory = await _service.GetAllInventory();
            return Ok(inventory);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Inventory>> GetInventoryById(Guid id)
        {
            var item = await _service.GetInventoryItem(id);
            
            if (item == null)
            {
                return NotFound($"Inventory item with ID {id} not found.");
            }
            
            return Ok(item);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateInventory(Guid id, [FromBody] Inventory inventory)
        { 
            if (id != inventory.Id)
            {
                return BadRequest("ID mismatch in route and body.");
            }

            await _service.UpdateInventoryItem(inventory); 
            
            return NoContent();
        }

    }
}