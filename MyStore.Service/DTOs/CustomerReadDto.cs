namespace MyStore.Service.DTOs
{
    public class CustomerReadDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public int PointsBalance { get; set; }

        public bool IsPremium { get; set; }

        public DateTime? LastPurchaseDate { get; set; }
    }
}
