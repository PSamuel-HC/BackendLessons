using FluentValidation;
using MyStore.Domain.Interfaces;
using MyStore.Service.DTOs.CustomerDTOs;

namespace MyStore.Service.Validators.CustomerDtoValidators
{
    public class CustomerCreateDtoValidator : CustomerValidator<CustomerCreateDto>
    {
        public CustomerCreateDtoValidator() 
        { }
    }
}
