using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.UserService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private readonly ICarrierService _carrierService;
        public CarriersController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var carriers = await _carrierService.Get();
            return Ok(carriers);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var carrier = await _carrierService.Get(id);
            if (carrier == null)
            {
                return NotFound();
            }
            return Ok(carrier);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Carrier value)
        {
            await _carrierService.Post(value);
            return Ok("Carrier added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Carrier value)
        {
            var carrier = await _carrierService.Get(id);
            if (carrier == null)
            {
                return NotFound();
            }
            await _carrierService.Put(id, value);
            return Ok("Carrier Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var carrier = await _carrierService.Get(id);
            if (carrier == null)
            {
                return NotFound();
            }
            await _carrierService.Delete(id);
            return Ok("Carrier Deleted Successfully");
        }
    }
}
