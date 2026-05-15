namespace MyStore.Service.DTOs.VectorDTOs
{
    public class AddEmbeddingDto
    {
        public int ProductId { get; set; }

        public string Description { get; set; } = string.Empty;

        public float[] Vector { get; set; } = [];
    }
}
