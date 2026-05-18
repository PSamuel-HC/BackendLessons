namespace MyStore.Service.DTOs.VectorDTOs
{
    public class VectorSearchDto
    {
        public float[] Vector { get; set; } = [];

        public int Limit { get; set; } = 5;
    }
}
