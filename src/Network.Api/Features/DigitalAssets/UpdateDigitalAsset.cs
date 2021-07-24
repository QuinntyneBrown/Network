using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateDigitalAsset
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.DigitalAsset).NotNull();
                RuleFor(request => request.DigitalAsset).SetValidator(new DigitalAssetValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Response : ResponseBase
        {
            public DigitalAssetDto DigitalAsset { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var digitalAsset = await _context.DigitalAssets.SingleAsync(x => x.DigitalAssetId == request.DigitalAsset.DigitalAssetId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    DigitalAsset = digitalAsset.ToDto()
                };
            }

        }
    }
}
