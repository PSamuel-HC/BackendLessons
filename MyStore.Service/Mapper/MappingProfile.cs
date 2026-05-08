using AutoMapper;
using MyStore.Domain.Model;
using MyStore.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerReadDto>()
                .ReverseMap();
        }
    }
}
