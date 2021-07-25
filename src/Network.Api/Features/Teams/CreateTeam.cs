using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateTeam
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Team).NotNull();
                RuleFor(request => request.Team).SetValidator(new TeamValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public TeamDto Team { get; set; }
        }

        public class Response: ResponseBase
        {
            public TeamDto Team { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var team = new Team();
                
                _context.Teams.Add(team);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Team = team.ToDto()
                };
            }
            
        }
    }
}
