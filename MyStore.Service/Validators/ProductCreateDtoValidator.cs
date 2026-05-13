using FluentValidation;
using MyStore.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Service.Validators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Product name can't be empty")
                .MaximumLength(200)
                .WithMessage("Product name can't have more than 200 characters");

            RuleFor(product => product.SKU)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("SKU can't be empty")
                .Matches(@"^[A-Z]{2,4}-\d{4,8}$")
                .WithMessage("SKU must contain 2 to 4 uppercase letters, followed by dash, followed by 4 to 8 digits (e.g. PROD-1042)");

            RuleFor(product => product.Manufacturer)
                .NotEmpty()
                .WithMessage("Product manufacturer can't be empty")
                .MaximumLength(150)
                .WithMessage("Product manufacturer can't have more than 150 characters");

            RuleFor(product => product.Manufacturer)
                .NotEmpty()
                .WithMessage("Product manufacturer can't be empty")
                .MaximumLength(150)
                .WithMessage("Product manufacturer can't have more than 150 characters");

            RuleFor(product => product.WarrantyMonths)
                .InclusiveBetween(0, 120)
                .WithMessage("Product warranty months must be between 0 and 120");

            RuleFor(product => product.Description)
               .MaximumLength(1000)
               .WithMessage("Product description can't have more than 1000 characters");
        }
    }
}
