using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyTeamController
    {
        private readonly IMediator _mediator;

        public CompanyTeamController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{companyTeamId}", Name = "GetCompanyTeamByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompanyTeamById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompanyTeamById.Response>> GetById([FromRoute] GetCompanyTeamById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.CompanyTeam == null)
            {
                return new NotFoundObjectResult(request.CompanyTeamId);
            }

            return response;
        }

        [HttpGet(Name = "GetCompanyTeamsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompanyTeams.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompanyTeams.Response>> Get()
            => await _mediator.Send(new GetCompanyTeams.Request());

        [HttpPost(Name = "CreateCompanyTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCompanyTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCompanyTeam.Response>> Create([FromBody] CreateCompanyTeam.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetCompanyTeamsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCompanyTeamsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCompanyTeamsPage.Response>> Page([FromRoute] GetCompanyTeamsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateCompanyTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCompanyTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCompanyTeam.Response>> Update([FromBody] UpdateCompanyTeam.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{companyTeamId}", Name = "RemoveCompanyTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCompanyTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCompanyTeam.Response>> Remove([FromRoute] RemoveCompanyTeam.Request request)
            => await _mediator.Send(request);

    }
}
