using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateProfileTechnology
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ProfileTechnology).NotNull();
                RuleFor(request => request.ProfileTechnology).SetValidator(new ProfileTechnologyValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ProfileTechnologyDto ProfileTechnology { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProfileTechnologyDto ProfileTechnology { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;

            public Handler(INetworkDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var profileTechnology = new ProfileTechnology();

                _context.ProfileTechnologies.Add(profileTechnology);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    ProfileTechnology = profileTechnology.ToDto()
                };
            }

        }
    }
}
