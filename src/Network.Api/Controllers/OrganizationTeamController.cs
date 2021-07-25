using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationTeamController
    {
        private readonly IMediator _mediator;

        public OrganizationTeamController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{organizationTeamId}", Name = "GetOrganizationTeamByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationTeamById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationTeamById.Response>> GetById([FromRoute]GetOrganizationTeamById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.OrganizationTeam == null)
            {
                return new NotFoundObjectResult(request.OrganizationTeamId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetOrganizationTeamsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationTeams.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationTeams.Response>> Get()
            => await _mediator.Send(new GetOrganizationTeams.Request());
        
        [HttpPost(Name = "CreateOrganizationTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateOrganizationTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateOrganizationTeam.Response>> Create([FromBody]CreateOrganizationTeam.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetOrganizationTeamsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationTeamsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationTeamsPage.Response>> Page([FromRoute]GetOrganizationTeamsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateOrganizationTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateOrganizationTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateOrganizationTeam.Response>> Update([FromBody]UpdateOrganizationTeam.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{organizationTeamId}", Name = "RemoveOrganizationTeamRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveOrganizationTeam.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveOrganizationTeam.Response>> Remove([FromRoute]RemoveOrganizationTeam.Request request)
            => await _mediator.Send(request);
        
    }
}
