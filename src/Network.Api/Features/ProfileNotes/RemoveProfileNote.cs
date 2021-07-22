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
    public class RemoveProfileNote
    {
        public class Request: IRequest<Response>
        {
            public Guid ProfileNoteId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProfileNoteDto ProfileNote { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var profileNote = await _context.ProfileNotes.SingleAsync(x => x.ProfileNoteId == request.ProfileNoteId);
                
                _context.ProfileNotes.Remove(profileNote);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProfileNote = profileNote.ToDto()
                };
            }
            
        }
    }
}
