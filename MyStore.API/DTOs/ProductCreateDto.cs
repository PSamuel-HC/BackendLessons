namespace MyStore.API.DTOs
{
    public class ProductCreateDto
    {
        // The User shouldn't send an ID; the DB generates it.
        public string Name { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public string Manufacturer { get; set; } = string.Empty;

        public int WarrantyMonths { get; set; }
        public string Description { get; set; } = string.Empty;


    }
}
