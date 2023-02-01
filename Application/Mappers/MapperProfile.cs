using Application.Dtos;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Products, ProductsDto>().ReverseMap();
            CreateMap<Providers, ProvidersDto>().ReverseMap();
        }
    }
}
