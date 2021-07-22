using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class GetLocationById
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
                return new () {
                    Location = (await _context.Locations.SingleOrDefaultAsync(x => x.LocationId == request.LocationId)).ToDto()
                };
            }
            
        }
    }
}
