using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateTeamTechnology
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.TeamTechnology).NotNull();
                RuleFor(request => request.TeamTechnology).SetValidator(new TeamTechnologyValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public TeamTechnologyDto TeamTechnology { get; set; }
        }

        public class Response : ResponseBase
        {
            public TeamTechnologyDto TeamTechnology { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var teamTechnology = new TeamTechnology();

                _context.TeamTechnologies.Add(teamTechnology);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    TeamTechnology = teamTechnology.ToDto()
                };
            }

        }
    }
}
