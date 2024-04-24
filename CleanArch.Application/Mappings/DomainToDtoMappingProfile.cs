using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductDto, ProductCreateCommand>().ReverseMap();
        CreateMap<ProductDto, ProductUpdateCommand>().ReverseMap();
    }
}