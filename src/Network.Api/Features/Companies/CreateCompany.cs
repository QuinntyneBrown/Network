using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Network.Api.Models;
using Network.Api.Core;
using Network.Api.Interfaces;

namespace Network.Api.Features
{
    public class CreateCompany
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Company).NotNull();
                RuleFor(request => request.Company).SetValidator(new CompanyValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public CompanyDto Company { get; set; }
        }

        public class Response: ResponseBase
        {
            public CompanyDto Company { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly INetworkDbContext _context;
        
            public Handler(INetworkDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var company = new Company();
                
                _context.Companies.Add(company);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Company = company.ToDto()
                };
            }
            
        }
    }
}
