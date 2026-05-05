namespace MyStore.API.DTOs
{
    public class CustomerCreateDto
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public int PointsBalance { get; set; }

        public bool IsPremium { get; set; }
    }
}
