using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class GetCompanyById
    {
        public class Request : IRequest<Response>
        {
            public Guid CompanyId { get; set; }
        }

        public class Response : ResponseBase
        {
            public CompanyDto Company { get; set; }
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
                    Company = (await _context.Companies.SingleOrDefaultAsync(x => x.CompanyId == request.CompanyId)).ToDto()
                };
            }

        }
    }
}
