using App.Api.Dtos;
using App.Domain.Models;
using AutoMapper;

namespace App.Api.Configurations.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderResponseDto>();
        }
    }
}