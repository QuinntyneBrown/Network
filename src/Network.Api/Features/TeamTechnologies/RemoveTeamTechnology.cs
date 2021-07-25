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
    public class RemoveTeamTechnology
    {
        public class Request: IRequest<Response>
        {
            public Guid TeamTechnologyId { get; set; }
        }

        public class Response: ResponseBase
        {
            public TeamTechnologyDto TeamTechnology { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var teamTechnology = await _context.TeamTechnologies.SingleAsync(x => x.TeamTechnologyId == request.TeamTechnologyId);
                
                _context.TeamTechnologies.Remove(teamTechnology);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    TeamTechnology = teamTechnology.ToDto()
                };
            }
            
        }
    }
}
