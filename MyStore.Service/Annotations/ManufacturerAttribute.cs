using System.ComponentModel.DataAnnotations;

namespace MyStore.Service.Annotations
{
    public class ManufacturerAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? manufacter = value?.ToString();

            if (!manufacter.StartsWith("PRD-"))
            {
                return new ValidationResult("Manufacter is invalid");
            }

            return ValidationResult.Success;

        }
    }
}
