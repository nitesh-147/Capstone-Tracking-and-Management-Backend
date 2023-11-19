using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.OrderItemService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderitemservice;
        public OrderItemsController(IOrderItemService orderitemservice)
        {
            _orderitemservice = orderitemservice;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orderItems = await _orderitemservice.Get();
            return Ok(orderItems);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var orderItem = await _orderitemservice.Get(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderItem value)
        {
            await _orderitemservice.Post(value);
            return Ok("orderItem added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] OrderItem value)
        {
            var orderItem = await _orderitemservice.Get(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            await _orderitemservice.Put(id, value);
            return Ok("orderItem Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var orderItem = await _orderitemservice.Get(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            await _orderitemservice.Delete(id);
            return Ok("orderItem Deleted Successfully");
        }
    }
}
