using FluentValidation;
using MediatR;
using Network.Api.Core;
using Network.Api.Interfaces;
using Network.Api.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Network.Api.Features
{
    public class CreateNote
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Note).NotNull();
                RuleFor(request => request.Note).SetValidator(new NoteValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public NoteDto Note { get; set; }
        }

        public class Response : ResponseBase
        {
            public NoteDto Note { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var note = new Note();

                _context.Notes.Add(note);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Note = note.ToDto()
                };
            }

        }
    }
}
