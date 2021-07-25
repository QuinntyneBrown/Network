using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateCompanyTeam
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.CompanyTeam).NotNull();
                RuleFor(request => request.CompanyTeam).SetValidator(new CompanyTeamValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public CompanyTeamDto CompanyTeam { get; set; }
        }

        public class Response : ResponseBase
        {
            public CompanyTeamDto CompanyTeam { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var companyTeam = new CompanyTeam();

                _context.CompanyTeams.Add(companyTeam);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    CompanyTeam = companyTeam.ToDto()
                };
            }

        }
    }
}
