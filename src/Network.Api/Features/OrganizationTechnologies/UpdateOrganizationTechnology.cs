using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateOrganizationTechnology
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.OrganizationTechnology).NotNull();
                RuleFor(request => request.OrganizationTechnology).SetValidator(new OrganizationTechnologyValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public OrganizationTechnologyDto OrganizationTechnology { get; set; }
        }

        public class Response : ResponseBase
        {
            public OrganizationTechnologyDto OrganizationTechnology { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var organizationTechnology = await _context.OrganizationTechnologies.SingleAsync(x => x.OrganizationTechnologyId == request.OrganizationTechnology.OrganizationTechnologyId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    OrganizationTechnology = organizationTechnology.ToDto()
                };
            }

        }
    }
}
