using AutoMapper;
using Mermas.Application.Merchant.Queries;

namespace Mermas.Application.Mappings
{
    public class MerchantMappings : Profile
    {
        public MerchantMappings()
        {
            CreateMap<Domain.Entities.Merchant, GetAllMerchantQueryResponse>();
        }
    }
}
