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
        }
    }
}
