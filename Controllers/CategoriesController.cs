using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.CategoryService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;
        public CategoriesController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryservice.Get();
            return Ok(categories);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var category = await _categoryservice.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category value)
        {
            await _categoryservice.Post(value);
            return Ok("category added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Category value)
        {
            var category = await _categoryservice.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryservice.Put(id, value);
            return Ok("category Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryservice.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryservice.Delete(id);
            return Ok("category Deleted Successfully");
        }
    }
}
