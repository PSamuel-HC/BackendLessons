namespace MyStore.API.DTOs
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string SKU { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public int WarrantyMonths { get; set; }
        public string DisplayName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

    }
}
