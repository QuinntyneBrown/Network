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
    public class GetOrganizationTechnologies
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<OrganizationTechnologyDto> OrganizationTechnologies { get; set; }
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
                    OrganizationTechnologies = await _context.OrganizationTechnologies.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
