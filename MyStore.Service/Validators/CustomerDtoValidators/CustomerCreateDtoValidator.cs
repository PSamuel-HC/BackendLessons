using FluentValidation;
using MyStore.Domain.Interfaces;
using MyStore.Service.DTOs;

namespace MyStore.Service.Validators.CustomerDtoValidators
{
    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateDtoValidator(ICustomerRepository repository) 
        {

            RuleFor(customer => customer.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                    .WithMessage("Email is required.")
                .EmailAddress()
                    .WithMessage("Invalid email format.")
                .MaximumLength(100)
                    .WithMessage("Email cannot exceed 100 characters.")
                .MustAsync(async (email, cancellation) =>
                {
                    await Task.Delay(100);
                    return !(email.EndsWith("@blocked.com") || email.EndsWith("@spam.com") || email.EndsWith("@fake.com"));
                })
                    .WithMessage("This email domain is not allowed.");

            RuleFor(customer => customer.FullName)
                .NotEmpty()
                    .WithMessage("Full name is required.")
                .MinimumLength(5) // Nota: debo poner la validacion minimum 5 primero con el when antes que el minum 2, sino no funciona
                .When(dto => dto.IsPremium)
                    .WithMessage("Premium customers must have a full name of at least 5 characters.")
                .MinimumLength(2)
                    .WithMessage("Full name must be at least 2 characters long.")
                .MaximumLength(150)
                    .WithMessage("Full name cannot exceed 150 characters.")
                .Must(fullName =>
                {
                    for (int i = 0; i < fullName.Length - 1; i++){
                        if (fullName[i] == ' ' && fullName[i + 1] == ' ') return false;
                    }
                    return true;
                })
                    .WithMessage("Full name cannot contain consecutive spaces.");
        }
    }
}
