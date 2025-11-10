using Microsoft.AspNetCore.Mvc;
using CafremaApp.Core.Entities;

namespace CafremaApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        public static List<Inventory> Inventories = [new Inventory(5, "Walls", "Skide god stand")];

        [HttpGet]
        public List<Inventory> GetAllInventory()
        {
            return Inventories;
        }

        [HttpGet]
        [Route("GetInventoryById")]
        public ActionResult GetInventoryById(int id)
        {
            return Ok(Inventories.Find(i => i.Id == id));
        }

        [HttpPut]
        public ActionResult UpdateInventory(int id, string name, string description)
        { 
            //InventoryService.Put(id, name, description)
            return Ok();
        }

    }
}