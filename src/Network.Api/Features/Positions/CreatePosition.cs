using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreatePosition
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Position).NotNull();
                RuleFor(request => request.Position).SetValidator(new PositionValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public PositionDto Position { get; set; }
        }

        public class Response : ResponseBase
        {
            public PositionDto Position { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var position = new Position();

                _context.Positions.Add(position);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Position = position.ToDto()
                };
            }

        }
    }
}
