using FluentValidation;
using MyStore.Service.DTOs.CustomerDTOs;

namespace MyStore.Service.Validators.CustomerDtoValidators
{
    public class CustomerUpdateDtoValidator: CustomerValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        { }
    }
}
