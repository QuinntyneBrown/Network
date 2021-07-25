using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class GetProfileTechnologyById
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
                return new () {
                    ProfileTechnology = (await _context.ProfileTechnologies.SingleOrDefaultAsync(x => x.ProfileTechnologyId == request.ProfileTechnologyId)).ToDto()
                };
            }
            
        }
    }
}
