using MediatR;
using Microsoft.EntityFrameworkCore;
using Network.Api.Core;
using Network.Api.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Network.Api.Features
{
    public class GetNotes
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<NoteDto> Notes { get; set; }
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
                    Notes = await _context.Notes.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
