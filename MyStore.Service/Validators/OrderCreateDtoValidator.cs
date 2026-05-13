using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MyStore.Domain.Interfaces;
using MyStore.Service.DTOs;

namespace MyStore.Service.Validators
{
    public class OrderCreateDtoValidators : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidators()
        {
            RuleFor(x => x.OrderNumber)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .MaximumLength(200)
                .Must(name => !name.Contains("  "));

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0)
                .WithMessage("Total amount must be greater than 0.");

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.ShippingAddress)
                .MaximumLength(500);

            RuleFor(x => x.ShippingAddress)
                .NotEmpty()
                .MaximumLength(500)
                .When(x => x.Status == Domain.Emuns.OrderStatus.Shipped || x.Status == Domain.Emuns.OrderStatus.Delivered);
        }
    }
}
