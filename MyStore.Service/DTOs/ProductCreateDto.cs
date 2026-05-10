using MyStore.Service.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Service.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Manufacturer { get; set; } = string.Empty;

        public int WarrantyMonths { get; set; }
        public string Description { get; set; } = string.Empty;


    }
}
