using AutoMapper;
using MateriaGris.Ecommerce.Application.Dtos;
using MateriaGris.Ecommerce.Domain.Entities;

namespace MateriaGris.Ecommerce.Application.Mappers
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
        }
    }
}