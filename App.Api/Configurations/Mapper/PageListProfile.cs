using App.Api.Dtos;
using App.Domain.Models;
using AutoMapper;

namespace App.Api.Configurations.Mapper
{
    public class PageListProfile : Profile
    {
        public PageListProfile()
        {
            CreateMap(typeof(PageList<>), typeof(PageListDto<>));
        }
    }
}