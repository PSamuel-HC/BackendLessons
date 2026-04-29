namespace GenericTypesAndConstraints.Models
{
    internal class Product: IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; } = string.Empty;
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(Guid id, string productName, double price)
        {
            Id = id;
            ProductName = productName;
            Price = price;
        }
    }
}
