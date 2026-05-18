namespace MyStore.Domain.Model
{
    public record VectorSearchResult(int ProductId, string Description, float Distance);
}
