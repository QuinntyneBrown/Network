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
    public class RemoveCompanyTeam
    {
        public class Request: IRequest<Response>
        {
            public Guid CompanyTeamId { get; set; }
        }

        public class Response: ResponseBase
        {
            public CompanyTeamDto CompanyTeam { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var companyTeam = await _context.CompanyTeams.SingleAsync(x => x.CompanyTeamId == request.CompanyTeamId);
                
                _context.CompanyTeams.Remove(companyTeam);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    CompanyTeam = companyTeam.ToDto()
                };
            }
            
        }
    }
}
