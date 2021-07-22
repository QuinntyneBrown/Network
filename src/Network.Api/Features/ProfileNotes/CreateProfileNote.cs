using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateProfileNote
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProfileNote).NotNull();
                RuleFor(request => request.ProfileNote).SetValidator(new ProfileNoteValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProfileNoteDto ProfileNote { get; set; }
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
                var profileNote = new ProfileNote();
                
                _context.ProfileNotes.Add(profileNote);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ProfileNote = profileNote.ToDto()
                };
            }
            
        }
    }
}
