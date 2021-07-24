using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class GetProfileById
    {
        public class Request : IRequest<Response>
        {
            public Guid ProfileId { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Profile = (await _context.Profiles
                    .Include(x => x.Experience)
                    .SingleOrDefaultAsync(x => x.ProfileId == request.ProfileId)).ToDto()
                };
            }

        }
    }
}
