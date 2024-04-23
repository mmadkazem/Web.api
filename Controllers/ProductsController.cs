using Microsoft.AspNetCore.Mvc;
using Webapi.services;
using Webapi.services.Dots;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto model)
        {
            var result = await _service.Add(model);
            if (!result.IsSuccessFull)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _service.Delete(id);
            if (!result.IsSuccessFull)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            if (!result.IsSuccessFull)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            if (!result.IsSuccessFull)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto model)
        {
            var result = await _service.GetAll();
            if (!result.IsSuccessFull)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}