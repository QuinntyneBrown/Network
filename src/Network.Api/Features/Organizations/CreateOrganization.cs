using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateOrganization
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Organization).NotNull();
                RuleFor(request => request.Organization).SetValidator(new OrganizationValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public OrganizationDto Organization { get; set; }
        }

        public class Response : ResponseBase
        {
            public OrganizationDto Organization { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var organization = new Organization();

                _context.Organizations.Add(organization);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Organization = organization.ToDto()
                };
            }

        }
    }
}
