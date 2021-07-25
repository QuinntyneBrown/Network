using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateOrganizationTeam
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.OrganizationTeam).NotNull();
                RuleFor(request => request.OrganizationTeam).SetValidator(new OrganizationTeamValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public OrganizationTeamDto OrganizationTeam { get; set; }
        }

        public class Response : ResponseBase
        {
            public OrganizationTeamDto OrganizationTeam { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var organizationTeam = await _context.OrganizationTeams.SingleAsync(x => x.OrganizationTeamId == request.OrganizationTeam.OrganizationTeamId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    OrganizationTeam = organizationTeam.ToDto()
                };
            }

        }
    }
}
