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
    public class RemoveLocation
    {
        public class Request: IRequest<Response>
        {
            public Guid LocationId { get; set; }
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
                var location = await _context.Locations.SingleAsync(x => x.LocationId == request.LocationId);
                
                _context.Locations.Remove(location);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Location = location.ToDto()
                };
            }
            
        }
    }
}
