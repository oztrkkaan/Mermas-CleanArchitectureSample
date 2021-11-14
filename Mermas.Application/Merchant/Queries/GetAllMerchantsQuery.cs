using AutoMapper;
using MediatR;
using Mermas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Merchant.Queries
{
    public class GetAllMerchantsQuery : IRequest<List<GetAllMerchantQueryResponse>>
    {
    }

    public class GetAllMerchantQueryHandler : IRequestHandler<GetAllMerchantsQuery, List<GetAllMerchantQueryResponse>>
    {
        IMermasDbContext _context;
        IMapper _mapper;

        public GetAllMerchantQueryHandler(IMermasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetAllMerchantQueryResponse>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
        {
            var merchants = await _context.Merchants.ToListAsync();

            return _mapper.Map<List<GetAllMerchantQueryResponse>>(merchants);
        }
    }

    public class GetAllMerchantQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
