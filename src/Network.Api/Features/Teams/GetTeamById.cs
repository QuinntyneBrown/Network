using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class GetTeamById
    {
        public class Request : IRequest<Response>
        {
            public Guid TeamId { get; set; }
        }

        public class Response : ResponseBase
        {
            public TeamDto Team { get; set; }
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
                    Team = (await _context.Teams.SingleOrDefaultAsync(x => x.TeamId == request.TeamId)).ToDto()
                };
            }

        }
    }
}
