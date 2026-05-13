using FluentValidation;
using MyStore.Domain.Interfaces;
using MyStore.Service.DTOs;

namespace MyStore.Service.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator(IProductRepository repository)
        {
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0.")
                .Must(price => decimal.Round(price, 2) == price)
                .WithMessage("Price must have at most 2 decimal places");
        }
    }
}
