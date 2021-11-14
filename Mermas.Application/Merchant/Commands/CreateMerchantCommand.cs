using MediatR;
using Mermas.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Mermas.Application.Merchant.Commands
{
    public class CreateMerchantCommand : IRequest<CreateMerchantResponse>
    {
        public string Title { get; set; }
    }

    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, CreateMerchantResponse>
    {
        IMermasDbContext _context;
        public CreateMerchantCommandHandler(IMermasDbContext context)
        {
            _context = context;
        }
        public async Task<CreateMerchantResponse> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            var merchant = new Domain.Entities.Merchant
            {
                Title = request.Title
            };
            _context.Merchants.Add(merchant);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateMerchantResponse
            {
                MerchantId = merchant.Id
            };
        }
    }
    public class CreateMerchantResponse
    {
        public int MerchantId { get; set; }
    }
}
