using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{companyId}", Name = "GetCompanyByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompanyById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompanyById.Response>> GetById([FromRoute] GetCompanyById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Company == null)
            {
                return new NotFoundObjectResult(request.CompanyId);
            }

            return response;
        }

        [HttpGet(Name = "GetCompaniesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompanies.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompanies.Response>> Get()
            => await _mediator.Send(new GetCompanies.Request());

        [HttpPost(Name = "CreateCompanyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCompany.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCompany.Response>> Create([FromBody] CreateCompany.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetCompaniesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompaniesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompaniesPage.Response>> Page([FromRoute] GetCompaniesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateCompanyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCompany.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCompany.Response>> Update([FromBody] UpdateCompany.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{companyId}", Name = "RemoveCompanyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCompany.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCompany.Response>> Remove([FromRoute] RemoveCompany.Request request)
            => await _mediator.Send(request);

    }
}
