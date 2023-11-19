using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.ShipmentService;
using TrackingApp.Services.ShippingMethodService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentservice;
        public ShipmentsController(IShipmentService shipmentservice)
        {
            _shipmentservice = shipmentservice;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shipments = await _shipmentservice.Get();
            return Ok(shipments);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var shipment = await _shipmentservice.Get(id);
            if (shipment == null)
            {
                return NotFound();
            }
            return Ok(shipment);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shipment value)
        {
            await _shipmentservice.Post(value);
            return Ok("shipment added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Shipment value)
        {
            var shipment = await _shipmentservice.Get(id);
            if (shipment == null)
            {
                return NotFound();
            }
            await _shipmentservice.Put(id, value);
            return Ok("shipment Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var shipment = await _shipmentservice.Get(id);
            if (shipment == null)
            {
                return NotFound();
            }
            await _shipmentservice.Delete(id);
            return Ok("shipment Deleted Successfully");
        }
    }
}
