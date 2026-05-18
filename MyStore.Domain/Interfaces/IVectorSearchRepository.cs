using MyStore.Domain.Model;

namespace MyStore.Domain.Interfaces
{
    public interface IVectorSearchRepository
    {
        Task AddAsync(int productId, string description, float[] embedding);

        Task<IEnumerable<VectorSearchResult>> SearchAsync(
            float[] queryVector, int limit = 5);
    }
}
