

namespace MyStore.Domain.Model
{
    public class ProductEmbeddingDocument
    {
        public int ProductId { get; set; }

        public string Description { get; set; } = string.Empty;

        public float[] Embedding { get; set; } = [];
    }
}
