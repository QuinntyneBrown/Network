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
    public class GetTeamTechnologiesPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<TeamTechnologyDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from teamTechnology in _context.TeamTechnologies
                            select teamTechnology;

                var length = await _context.TeamTechnologies.CountAsync();

                var teamTechnologies = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = teamTechnologies
                };
            }

        }
    }
}
