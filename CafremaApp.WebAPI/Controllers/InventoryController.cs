using CafremaApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using CafremaApp.Core.Entities;

namespace CafremaApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public ActionResult GetAllInventory()
        {
            return Ok(_inventoryService.GetAllInventory());
        }

        [HttpGet]
        [Route("GetInventoryById")]
        public ActionResult GetInventoryById(Guid id)
        {
            return Ok(_inventoryService.GetInventoryItem(id));
        }

        [HttpPut]
        public ActionResult UpdateInventory(int id, string name, string description)
        { 
            //InventoryService.Put(id, name, description)
            return Ok();
        }

    }
}