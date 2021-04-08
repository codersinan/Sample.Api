using AutoMapper;
using Sample.Api.Entities;
using Sample.Api.Requests;
using Sample.Api.Responses;

namespace Sample.Api.Mapping
{
    public class ProductMappings:Profile
    {
        public ProductMappings()
        {
            CreateMap<AddProductRequest, Product>();
            CreateMap<Product, ProductResponse>();

            CreateMap<UpdateProductRequest, Product>();
        }
    }
}