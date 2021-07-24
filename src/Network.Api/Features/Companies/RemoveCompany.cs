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
    public class RemoveCompany
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
                var company = await _context.Companies.SingleAsync(x => x.CompanyId == request.CompanyId);

                _context.Companies.Remove(company);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Company = company.ToDto()
                };
            }

        }
    }
}
