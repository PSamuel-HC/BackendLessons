namespace MyStore.Service.DTOs
{
    public class CustomerCreateDto
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }

        public bool IsPremium { get; set; }
    }
}