using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateOrganizationTeam
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.OrganizationTeam).NotNull();
                RuleFor(request => request.OrganizationTeam).SetValidator(new OrganizationTeamValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public OrganizationTeamDto OrganizationTeam { get; set; }
        }

        public class Response: ResponseBase
        {
            public OrganizationTeamDto OrganizationTeam { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var organizationTeam = new OrganizationTeam();
                
                _context.OrganizationTeams.Add(organizationTeam);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    OrganizationTeam = organizationTeam.ToDto()
                };
            }
            
        }
    }
}
