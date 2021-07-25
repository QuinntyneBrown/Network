using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class RemoveTeam
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
                var team = await _context.Teams.SingleAsync(x => x.TeamId == request.TeamId);

                _context.Teams.Remove(team);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Team = team.ToDto()
                };
            }

        }
    }
}
