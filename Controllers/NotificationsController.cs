using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.NotificationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationservice;
        public NotificationsController(INotificationService notificationservice)
        {
            _notificationservice = notificationservice;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var notifications = await _notificationservice.Get();
            return Ok(notifications);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var notification = await _notificationservice.Get(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Notification value)
        {
            await _notificationservice.Post(value);
            return Ok("Notification added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Notification value)
        {
            var notification = await _notificationservice.Get(id);
            if (notification == null)
            {
                return NotFound();
            }
            await _notificationservice.Put(id, value);
            return Ok("Notification Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var notification = await _notificationservice.Get(id);
            if (notification == null)
            {
                return NotFound();
            }
            await _notificationservice.Delete(id);
            return Ok("Notification Deleted Successfully");
        }
    }
}
