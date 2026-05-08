using AutoMapper;
using MyStore.Domain.Interfaces;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerReadDto>> GetCustomersAsync()
        {
            var customers = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CustomerReadDto>>(customers);
        }

        public async Task<CustomerReadDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
            {
                return null;
            }

            return _mapper.Map<CustomerReadDto>(customer);
        }

        public async Task<CustomerReadDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            var customer = _mapper.Map<Customer>(customerCreateDto);

            await _repository.AddAsync(customer);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CustomerReadDto>(customer);
        }

        public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
            {
                return false;
            }

            _mapper.Map(customerUpdateDto, customer);

            _repository.Update(customer);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
            {
                return false;
            }

            _repository.Delete(customer);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}