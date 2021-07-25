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
    public class RemoveProfileTechnology
    {
        public class Request: IRequest<Response>
        {
            public Guid ProfileTechnologyId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProfileTechnologyDto ProfileTechnology { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var profileTechnology = await _context.ProfileTechnologies.SingleAsync(x => x.ProfileTechnologyId == request.ProfileTechnologyId);
                
                _context.ProfileTechnologies.Remove(profileTechnology);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProfileTechnology = profileTechnology.ToDto()
                };
            }
            
        }
    }
}
