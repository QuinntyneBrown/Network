using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateNote
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Note).NotNull();
                RuleFor(request => request.Note).SetValidator(new NoteValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public NoteDto Note { get; set; }
        }

        public class Response: ResponseBase
        {
            public NoteDto Note { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var note = await _context.Notes.SingleAsync(x => x.NoteId == request.Note.NoteId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Note = note.ToDto()
                };
            }
            
        }
    }
}
