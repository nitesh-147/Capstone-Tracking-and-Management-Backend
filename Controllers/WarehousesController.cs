using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.WarehouseService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var warehouses = await _warehouseService.Get();
            return Ok(warehouses);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var warehouse = await _warehouseService.Get(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Warehouse value)
        {
            await _warehouseService.Post(value);
            return Ok("Warehouse added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Warehouse value)
        {
            var warehouse = await _warehouseService.Get(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            await _warehouseService.Put(id, value);
            return Ok("Warehouse Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var warehouse = await _warehouseService.Get(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            await _warehouseService.Delete(id);
            return Ok("Warehouse Deleted Successfully");
        }
    }
}
