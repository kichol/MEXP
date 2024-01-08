using AutoMapper;

using MediaExpert.Products.Domain.Entities;
using MediaExpert.Application.Features.Products.Queries.GetProductsList;
using MediaExpert.Products.Application.Features.Products.Commands.CreateProduct;
using MediaExpert.Application.Features.Products.Queries.GetProductDetail;
using MediaExpert.Application.Features.Products.Commands.UpdateProduct;

namespace MediaExpert.Products.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListVm>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, ProductDetailVm>().ReverseMap();
            CreateMap<Product, CreateProductDto>();


        }
    }
}
