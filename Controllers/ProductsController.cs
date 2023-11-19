using Microsoft.AspNetCore.Mvc;
using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.ProductService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productservice;
        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productservice.Get();
            return Ok(products);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productservice.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product value)
        {
            await _productservice.Post(value);
            return Ok("product added Successfully");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Product value)
        {
            var product = await _productservice.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productservice.Put(id, value);
            return Ok("product Updated Successfully");
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productservice.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productservice.Delete(id);
            return Ok("product Deleted Successfully");
        }
    }
}
