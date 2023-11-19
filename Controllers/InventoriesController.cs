using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.InventoryService;
using TrackingApp.Services.NotificationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoryService _inventoryservice;
        public InventoriesController(IInventoryService inventoryservice)
        {
            _inventoryservice = inventoryservice;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var inventories = await _inventoryservice.Get();
            return Ok(inventories);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var inventory = await _inventoryservice.Get(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inventory inventory)
        {
            await _inventoryservice.Post(inventory);
            return Ok("inventory added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Inventory value)
        {
            var inventory = await _inventoryservice.Get(id);
            if (inventory == null)
            {
                return NotFound();
            }
            await _inventoryservice.Put(id, value);
            return Ok("Notification Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var inventory = await _inventoryservice.Get(id);
            if (inventory == null)
            {
                return NotFound();
            }
            await _inventoryservice.Delete(id);
            return Ok("Notification Deleted Successfully");
        }
    }
}
