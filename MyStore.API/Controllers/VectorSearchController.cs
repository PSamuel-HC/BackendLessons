using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Interfaces;
using MyStore.Service.DTOs.VectorDTOs;

namespace MyStore.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Tags("Vector Search")]
    public class VectorSearchController(IVectorSearchRepository repository) : ControllerBase
    {
        [HttpPost("embeddings")]
        [EndpointSummary("Store a product embedding")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEmbedding(AddEmbeddingDto dto)
        {
            await repository.AddAsync(dto.ProductId, dto.Description, dto.Vector);
            return Created();
        }

        [HttpPost("search")]
        [EndpointSummary("Find the most similar products to a query vector")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Search(VectorSearchDto dto)
        {
            var results = await repository.SearchAsync(dto.Vector, dto.Limit);
            return Ok(results);
        }
    }
}
