using AutoMapper;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;

namespace MyStore.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerReadDto>().ReverseMap();

            CreateMap<Customer, CustomerCreateDto>().ReverseMap();

            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();

            CreateMap<Product, ProductReadDto>()
                .ForMember(s => s.DisplayName, opt => opt.MapFrom(d => $"{d.Name} - {d.Manufacturer}"))
                .ReverseMap()
                .ForMember(s => s.Manufacturer, opt => opt.MapFrom(d => d.DisplayName.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[1]))
                .ForMember(s => s.Name, opt => opt.MapFrom(d => d.DisplayName.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[0]));
            
            CreateMap<Product, ProductCreateDto>().ReverseMap();

            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            CreateMap<Employee, EmployeeReadDto>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                .ReverseMap();

            CreateMap<Employee, EmployeeCreateDto>()
                .ReverseMap();

            CreateMap<Employee, EmployeeUpdateDto>()
                .ReverseMap();
                
            CreateMap<EmployeeUpdateDto, Employee>()
                .ReverseMap();
        }
    }
}
