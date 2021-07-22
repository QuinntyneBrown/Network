using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateProfile
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProfileDto Profile { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var profile = new Profile();
                
                _context.Profiles.Add(profile);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Profile = profile.ToDto()
                };
            }
            
        }
    }
}
