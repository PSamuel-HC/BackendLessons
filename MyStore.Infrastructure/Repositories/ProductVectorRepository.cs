using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using Pgvector.EntityFrameworkCore;

namespace MyStore.Infrastructure.Repositories
{
    public class ProductVectorRepository(VectorDbContext context) : IVectorSearchRepository
    {
        public async Task AddAsync(int productId, string description, float[] embedding)
        {
            context.ProductEmbeddings.Add(new ProductEmbeddingDocument()
            {
                ProductId = productId,
                Description = description,
                Embedding = embedding
            });

            await context.SaveChangesAsync();

            //await using var conn = await dataSource.OpenConnectionAsync();
            //await using var cmd = conn.CreateCommand();

            //cmd.CommandText = """
            //    INSERT INTO product_embeddings (product_id, description, embedding)
            //    VALUES ($1, $2, $3)
            //    """;

            //cmd.Parameters.AddWithValue(productId);
            //cmd.Parameters.AddWithValue(description);
            //cmd.Parameters.AddWithValue(new Pgvector.Vector(embedding));

            //await cmd.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<VectorSearchResult>> SearchAsync(float[] queryVector, int limit = 5)
        {
            Pgvector.Vector query = new Pgvector.Vector(queryVector);

            var results = await context.ProductEmbeddings.Select(e => new
            {
                e.ProductId,
                e.Description,
                Distance = e.Embedding.CosineDistance(query),
            })
            .OrderBy(e => e.Distance)
            .Take(limit).ToListAsync();

            return results.Select(r =>
                new VectorSearchResult() { ProductId = r.ProductId, Description = r.Description, Distance = (float)r.Distance });

            //await using var conn = await dataSource.OpenConnectionAsync();
            //await using var cmd = conn.CreateCommand();

            //// <=> is cosine distance — lower value = more similar
            //cmd.CommandText = """
            //    SELECT product_id, description,
            //           embedding <=> $1 AS distance
            //    FROM   product_embeddings
            //    ORDER  BY distance
            //    LIMIT  $2
            //    """;

            //cmd.Parameters.AddWithValue(new Pgvector.Vector(queryVector));
            //cmd.Parameters.AddWithValue(limit);

            //var results = new List<VectorSearchResult>();

            //await using var reader = await cmd.ExecuteReaderAsync();
            //while (await reader.ReadAsync())
            //{
            //    results.Add(new VectorSearchResult() 
            //    { 
            //        ProductId = reader.GetInt32(0), 
            //        Description = reader.GetString(1), 
            //        Distance = (float)reader.GetDouble(2) 
            //    });
            //}

            //return results;
        }
    }
}
