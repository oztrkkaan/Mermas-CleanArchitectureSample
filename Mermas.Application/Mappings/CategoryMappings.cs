using AutoMapper;
using Mermas.Application.Categories.Queries;
using Mermas.Application.Products.Queries;
using Mermas.Domain.Entities;

namespace Mermas.Application.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, GetAllCategoriesResponse>();
            CreateMap<Category, GetProductCategoryByFilter>();
        }
    }
}
