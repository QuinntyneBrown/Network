using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Network.Api.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Network.Api.Features
{
    public class UpdateAvatarDigitalAssetId
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }
        }

        public class Request : IRequest<Response> { 
            public ProfileDto Profile { get; set; }        
        }

        public class Response
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var profile = await _context.Profiles.SingleAsync(x => x.ProfileId == request.Profile.ProfileId);

                profile.SetAvatarDigitalAssetId(request.Profile.AvatarDigitalAssetId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Profile = profile.ToDto()
                };
            }
        }
    }
}
