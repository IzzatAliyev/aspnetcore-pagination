using App.Api.Dtos;
using App.Domain.Models;
using AutoMapper;

namespace App.Api.Configurations.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDto>();
        }
    }
}