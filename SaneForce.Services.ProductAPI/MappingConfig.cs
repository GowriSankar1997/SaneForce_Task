using AutoMapper;
using SaneForce.Services.ProductAPI.Models;
using SaneForce.Services.ProductAPI.Models.Dto;

namespace SaneForce.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {

                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<ProductOrderDto, OrderDetails>();
                config.CreateMap<OrderDetails, ProductOrderDto>();
            });
            return mappingConfig;
        }
    }
}
