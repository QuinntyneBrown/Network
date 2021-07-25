using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateOrganizationTechnology
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.OrganizationTechnology).NotNull();
                RuleFor(request => request.OrganizationTechnology).SetValidator(new OrganizationTechnologyValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public OrganizationTechnologyDto OrganizationTechnology { get; set; }
        }

        public class Response: ResponseBase
        {
            public OrganizationTechnologyDto OrganizationTechnology { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var organizationTechnology = new OrganizationTechnology();
                
                _context.OrganizationTechnologies.Add(organizationTechnology);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    OrganizationTechnology = organizationTechnology.ToDto()
                };
            }
            
        }
    }
}
