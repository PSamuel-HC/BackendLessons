namespace MyStore.API.DTOs
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int WarrantyMonths { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
