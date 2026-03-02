using APPLICATION.DTOs;
using APPLICATION.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CQR.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpGet("GetModel{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpPost("PostModel")]
        public async Task<IActionResult> PostModel(ProductDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("PutModel")]
        public async Task<IActionResult> Put(ProductDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("DeleteModel/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
