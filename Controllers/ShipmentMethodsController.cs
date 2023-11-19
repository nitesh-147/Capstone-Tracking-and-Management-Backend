using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.ShippingMethodService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentMethodsController : ControllerBase
    {
        private readonly IShipmentMethodService _shipmentmethodservice;
        public ShipmentMethodsController(IShipmentMethodService shipmentmethodservice)
        {
            _shipmentmethodservice = shipmentmethodservice;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shipmentmethods = await _shipmentmethodservice.Get();
            return Ok(shipmentmethods);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var shipmentmethod = await _shipmentmethodservice.Get(id);
            if (shipmentmethod == null)
            {
                return NotFound();
            }
            return Ok(shipmentmethod);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShippingMethod value)
        {
            await _shipmentmethodservice.Post(value);
            return Ok("Carrier added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ShippingMethod value)
        {
            var shipmentmethod = await _shipmentmethodservice.Get(id);
            if (shipmentmethod == null)
            {
                return NotFound();
            }
            await _shipmentmethodservice.Put(id, value);
            return Ok("Carrier Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var shipmentmethod = await _shipmentmethodservice.Get(id);
            if (shipmentmethod == null)
            {
                return NotFound();
            }
            await _shipmentmethodservice.Delete(id);
            return Ok("Carrier Deleted Successfully");
        }
    }
}
