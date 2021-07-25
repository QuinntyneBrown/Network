using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using Network.Api.Models;

namespace Network.Api.Features
{
    public class CreateProfileExperience
    {
        public class Request : IRequest<Response>
        {
            public Guid ProfileId { get; set; }
            public PositionDto Position { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var profile = await _context.Profiles
                    .Include(x => x.Experience)
                    .SingleAsync(x => x.ProfileId == request.ProfileId);

                profile.Experience.Add(
                    new Position(request.Position.OrganizationId, request.Position.Title)
                    );

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Profile = profile.ToDto()
                };
            }
        }
    }
}
