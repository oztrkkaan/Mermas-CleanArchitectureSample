using AutoMapper;
using Mermas.Application.Products.Queries;
using Mermas.Domain.Entities;

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


        }
    }
}
