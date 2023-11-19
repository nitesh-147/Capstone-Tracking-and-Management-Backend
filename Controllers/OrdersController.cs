using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TrackingApp.Model;
using TrackingApp.Services.OrderService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderServive)
        {
            _orderService = orderServive;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderService.Get();
            return Ok(orders);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var order = await _orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order value)
        {
            await _orderService.Post(value);
            return Ok(new
            {
                Message="Order added successfully"
            });
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Order value)
        {
            var order = await _orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            await _orderService.Put(id, value);
            return Ok("Order Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var order = await _orderService.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            await _orderService.Delete(id);
            return Ok("Order Deleted Successfully");
        }
    }
}
