using APPLICATION.DTOs;
using AutoMapper;
using DOMAIN.Entities;


namespace APPLICATION.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
