using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateTechnology
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Technology).NotNull();
                RuleFor(request => request.Technology).SetValidator(new TechnologyValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public TechnologyDto Technology { get; set; }
        }

        public class Response : ResponseBase
        {
            public TechnologyDto Technology { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var technology = await _context.Technologies.SingleAsync(x => x.TechnologyId == request.Technology.TechnologyId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Technology = technology.ToDto()
                };
            }

        }
    }
}
