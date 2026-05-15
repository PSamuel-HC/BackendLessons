namespace MyStore.Domain.Model
{
    public class VectorSearchResult
    {
        public int ProductId { get; set; }

        public string Description { get; set; } = string.Empty;

        public float Distance { get; set; }
    }
}
