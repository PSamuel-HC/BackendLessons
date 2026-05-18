using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using Pgvector;
using Pgvector.EntityFrameworkCore;

namespace MyStore.Infrastructure.Repositories
{
    public class ProductVectorRepository(VectorDbContext context) : IVectorSearchRepository
    {
        public async Task AddAsync(int productId, string description, float[] embedding)
        {
            context.ProductEmbeddings.Add(new ProductEmbeddingDocument
            {
                ProductId   = productId,
                Description = description,
                Embedding   = embedding
            });

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VectorSearchResult>> SearchAsync(float[] queryVector, int limit = 5)
        {
            var query = new Vector(queryVector);

            var results = await context.ProductEmbeddings
                .Select(e => new
                {
                    e.ProductId,
                    e.Description,
                    Distance = e.Embedding.CosineDistance(query)
                })
                .OrderBy(e => e.Distance)
                .Take(limit)
                .ToListAsync();

            return results.Select(r => new VectorSearchResult(r.ProductId, r.Description, (float)r.Distance));
        }
    }
}
