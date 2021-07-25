using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Core;
using Network.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Features
{
    public class UpdateSkill
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Skill).NotNull();
                RuleFor(request => request.Skill).SetValidator(new SkillValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public SkillDto Skill { get; set; }
        }

        public class Response: ResponseBase
        {
            public SkillDto Skill { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var skill = await _context.Skills.SingleAsync(x => x.SkillId == request.Skill.SkillId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Skill = skill.ToDto()
                };
            }
            
        }
    }
}
