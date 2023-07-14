using AutoMapper;
using KampETicaret.Application.Features.Commands.ProductCommands.CreateProduct;
using KampETicaret.Application.Features.Commands.ProductCommands.DeleteProduct;
using KampETicaret.Application.Features.Commands.ProductCommands.UpdateProduct;
using KampETicaret.Application.Features.Queries.ProductQueries.GetAllProduct;
using KampETicaret.Application.Features.Queries.ProductQueries.GetByIdProduct;
using KampETicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Profiles.ProductProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Create Product Mapping
            CreateMap<CreateProductCommand,Product>().ReverseMap();
            CreateMap<CreateProductCommandDto,Product>().ReverseMap();

            //Update Product Mapping
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
            CreateMap<UpdateProductCommandDto, Product>().ReverseMap();

            //Delete Product Mapping
            CreateMap<DeleteProductCommand, Product>().ReverseMap();

            //GetAll Product Mapping
            CreateMap<GetAllProductQueryDto, Product>().ReverseMap();

            //GetById Product Mapping
            CreateMap<GetByIdProductDto, Product>().ReverseMap();
        }
    }
}
