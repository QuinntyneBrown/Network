using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Network.Api.Extensions;
using Network.Api.Core;
using Network.Api.Interfaces;
using Network.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class GetOrganizationsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<OrganizationDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from organization in _context.Organizations
                            select organization;

                var length = await _context.Organizations.CountAsync();

                var organizations = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = organizations
                };
            }

        }
    }
}
