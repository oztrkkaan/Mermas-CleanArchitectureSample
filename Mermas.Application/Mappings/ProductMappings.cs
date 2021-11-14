using AutoMapper;
using Mermas.Application.Products.Commands;
using Mermas.Application.Products.Queries;
using Mermas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mermas.Application.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, GetProductsByFilterResponse>()
                .ForMember(dest => dest.Category, act =>
                  {
                      act.MapFrom(src => src.Category);
                  });

            CreateMap<UpdateProductInfoCommand, Product>()
                .ForMember(dest => dest.Category, act => act.MapFrom(src => new Category
                {
                    Id = src.CategoryId
                }));
        }
    }
}
