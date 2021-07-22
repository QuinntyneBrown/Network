using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateLocation
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Location).NotNull();
                RuleFor(request => request.Location).SetValidator(new LocationValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public LocationDto Location { get; set; }
        }

        public class Response: ResponseBase
        {
            public LocationDto Location { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var location = new Location();
                
                _context.Locations.Add(location);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Location = location.ToDto()
                };
            }
            
        }
    }
}
