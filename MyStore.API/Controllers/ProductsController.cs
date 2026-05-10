using Microsoft.AspNetCore.Mvc;
using MyStore.API.Annotations;
using MyStore.Service.DTOs;
using MyStore.Service.Products;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {

        // GET: api/products
        [HttpGet]
        [EndpointAttribute]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts()
        {
            IEnumerable<ProductReadDto> products = await productService.GetProductsAsync();

            return Ok(products);
        }

        // GET: api/products/{id}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //        return NotFound();

        //    var dto = new ProductReadDto
        //    {
        //        Id = product.Id,
        //        SKU = product.SKU,
        //        Price = product.Price,
        //        WarrantyMonths = product.WarrantyMonths,
        //        Description = product.Description,
        //        DisplayName = product.Name + " - " + product.Manufacturer
        //    };

        //    return Ok(dto);
        //}

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto dto)
        {
            ProductReadDto productResponse = await productService.CreateProductAsync(dto);
            //// 1. MAPPING: DTO -> Entity
            //var product = new Product
            //{
            //    Name = dto.Name,
            //    SKU = dto.SKU,
            //    Price = dto.Price,
            //    Manufacturer = dto.Manufacturer,
            //    WarrantyMonths = dto.WarrantyMonths,
            //    Description = dto.Description
            //};

            //// 2. Persist to Database
            //_context.Products.Add(product);
            //await _context.SaveChangesAsync();

            //// 3. Convert back to ReadDto to show the user the result (with the new ID)
            //var resultDto = new ProductReadDto
            //{
            //    Id = product.Id,
            //    SKU = product.SKU,
            //    Price = product.Price,
            //    WarrantyMonths = product.WarrantyMonths,
            //    Description = product.Description,
            //    DisplayName = product.Name + " - " + product.Manufacturer
            //};

            return CreatedAtAction(nameof(GetProducts), new { id = productResponse.Id }, productResponse);
        }



        //// PUT: api/products/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto dto)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //        return NotFound();

        //    product.Name = dto.Name;
        //    product.SKU = dto.SKU;
        //    product.Price = dto.Price;
        //    product.Manufacturer = dto.Manufacturer;
        //    product.WarrantyMonths = dto.WarrantyMonths;
        //    product.Description = dto.Description;

        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //// DELETE: api/products/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //        return NotFound();

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


    }
}