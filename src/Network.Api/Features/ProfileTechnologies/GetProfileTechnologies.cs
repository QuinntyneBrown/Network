using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class GetProfileTechnologies
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<ProfileTechnologyDto> ProfileTechnologies { get; set; }
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
                    ProfileTechnologies = await _context.ProfileTechnologies.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
