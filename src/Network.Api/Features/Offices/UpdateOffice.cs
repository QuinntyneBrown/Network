using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateOffice
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Office).NotNull();
                RuleFor(request => request.Office).SetValidator(new OfficeValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public OfficeDto Office { get; set; }
        }

        public class Response: ResponseBase
        {
            public OfficeDto Office { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var office = await _context.Offices.SingleAsync(x => x.OfficeId == request.Office.OfficeId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Office = office.ToDto()
                };
            }
            
        }
    }
}
