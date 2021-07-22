using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateOrganization
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Organization).NotNull();
                RuleFor(request => request.Organization).SetValidator(new OrganizationValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public OrganizationDto Organization { get; set; }
        }

        public class Response: ResponseBase
        {
            public OrganizationDto Organization { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var organization = await _context.Organizations.SingleAsync(x => x.OrganizationId == request.Organization.OrganizationId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Organization = organization.ToDto()
                };
            }
            
        }
    }
}
