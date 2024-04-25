using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto productDto)
        {
            await productService.AddAsync(productDto);
            return Ok(productDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDto productDto)
        {
            await productService.UpdateAsync(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.RemoveAsync(id);
            return Ok();
        }
    }
}
