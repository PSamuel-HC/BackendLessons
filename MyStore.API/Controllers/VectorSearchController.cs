using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Interfaces;
using MyStore.Service.DTOs.VectorDTOs;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class VectorSearchController(IVectorSearchRepository repository) : ControllerBase
    {

        [HttpPost("embeddings")]
        public async Task<IActionResult> AddEmbedding(AddEmbeddingDto dto)
        {
            await repository.AddAsync(dto.ProductId, dto.Description, dto.Vector);
            return Created();
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(VectorSearchDto dto)
        {
            var results = await repository.SearchAsync(dto.Vector, dto.Limit);
            return Ok(results);
        }
    }
}
