namespace MyStore.API.DTOs
{
    public class ProductUpdateDto
    {
        // The User shouldn't send an ID; the DB generates it.
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public int WarrantyMonths { get; set; }
        public string Description { get; set; }

    }
}