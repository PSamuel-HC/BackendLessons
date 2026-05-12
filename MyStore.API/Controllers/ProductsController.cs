using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyStore.API.Annotations.MyStore.API.Annotations;
using MyStore.Service.DTOs;
using MyStore.Service.Products;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        // GET: api/products
        [HttpGet]
        [EndpointInformation]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {
            IEnumerable<ProductReadDto> dtos = await productService.GetProductsAsync();
            return Ok(dtos);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        {
            ProductReadDto dto = await productService.GetProduct(id);
            return Ok(dto);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto dto)
        {
           
            ProductReadDto resultDto = await productService.CreateProduct(dto);
            return CreatedAtAction(nameof(GetProducts), new { id = resultDto.Id }, resultDto);
        }



        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto dto)
        {
            await productService.UpdateProduct(id, dto);

           return NoContent();
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productService.DeleteProduct(id);

           return NoContent();
        }


    }
}