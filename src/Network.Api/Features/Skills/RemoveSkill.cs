using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class RemoveSkill
    {
        public class Request: IRequest<Response>
        {
            public Guid SkillId { get; set; }
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
                var skill = await _context.Skills.SingleAsync(x => x.SkillId == request.SkillId);
                
                _context.Skills.Remove(skill);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Skill = skill.ToDto()
                };
            }
            
        }
    }
}
