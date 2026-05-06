namespace MyStore.API.DTOs
{
    public class ProductCreateDto
    {
        // The User shouldn't send an ID; the DB generates it.
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public decimal InternalCost { get; set; }
    }
}
