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
    public class RemoveOrganization
    {
        public class Request : IRequest<Response>
        {
            public Guid OrganizationId { get; set; }
        }

        public class Response : ResponseBase
        {
            public OrganizationDto Organization { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var organization = await _context.Organizations.SingleAsync(x => x.OrganizationId == request.OrganizationId);

                _context.Organizations.Remove(organization);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Organization = organization.ToDto()
                };
            }

        }
    }
}
