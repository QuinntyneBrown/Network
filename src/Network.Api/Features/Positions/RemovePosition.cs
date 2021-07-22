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
    public class RemovePosition
    {
        public class Request: IRequest<Response>
        {
            public Guid PositionId { get; set; }
        }

        public class Response: ResponseBase
        {
            public PositionDto Position { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var position = await _context.Positions.SingleAsync(x => x.PositionId == request.PositionId);
                
                _context.Positions.Remove(position);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Position = position.ToDto()
                };
            }
            
        }
    }
}
