using AutoMapper;
using Azure;
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
            var deleted = await _inventoryService.DeleteInventoryItem(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
        
        [HttpPost]
        [Route("CreateInventory")]
        public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryDTO inventory)
        {
            await _inventoryService.CreateInventoryItem(inventory);
            return Ok();
        }

        // [HttpPatch("{Id}")]
        // public async Task<IActionResult> PatchInventory(Guid Id, [FromBody] JsonPatchDocument<InventoryDTO> patchDoc)
        // {
        //     if (patchDoc == null) return BadRequest();
        //
        //     var inventory = await _inventoryService.GetInventoryItem(Id);
        //     
        //     if (inventory == null) return NotFound();
        //     
        //     patchDoc.ApplyTo(inventory, ModelState);
        //
        //     //Check om patching lykkedes, altso om info passer med model
        //     if (!TryValidateModel(inventory)) return BadRequest(ModelState);
        //     
        //     //Updater DB
        //     await _inventoryService.UpdateInventoryItem(inventory);
        //     return Ok();
        // }
        

        [HttpPut]
        [Route("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory([FromBody] InventoryDTO inventory)
        {
            await _inventoryService.UpdateInventoryItem(inventory);
            return Ok();
        }

    }
}