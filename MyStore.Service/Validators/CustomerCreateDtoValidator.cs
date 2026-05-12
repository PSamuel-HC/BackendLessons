using FluentValidation;
using MyStore.Domain.Interfaces;
using MyStore.Service.DTOs;

namespace MyStore.Service.Validators
{
    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateDtoValidator(ICustomerRepository repository) 
        {
        }
    }
}
