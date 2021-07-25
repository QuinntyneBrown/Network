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
    public class RemoveOffice
    {
        public class Request : IRequest<Response>
        {
            public Guid OfficeId { get; set; }
        }

        public class Response : ResponseBase
        {
            public OfficeDto Office { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var office = await _context.Offices.SingleAsync(x => x.OfficeId == request.OfficeId);

                _context.Offices.Remove(office);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Office = office.ToDto()
                };
            }

        }
    }
}
