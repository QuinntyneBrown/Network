using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamTechnologyController
    {
        private readonly IMediator _mediator;

        public TeamTechnologyController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{teamTechnologyId}", Name = "GetTeamTechnologyByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTeamTechnologyById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTeamTechnologyById.Response>> GetById([FromRoute]GetTeamTechnologyById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.TeamTechnology == null)
            {
                return new NotFoundObjectResult(request.TeamTechnologyId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetTeamTechnologiesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTeamTechnologies.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTeamTechnologies.Response>> Get()
            => await _mediator.Send(new GetTeamTechnologies.Request());
        
        [HttpPost(Name = "CreateTeamTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTeamTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTeamTechnology.Response>> Create([FromBody]CreateTeamTechnology.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetTeamTechnologiesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetTeamTechnologiesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetTeamTechnologiesPage.Response>> Page([FromRoute]GetTeamTechnologiesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateTeamTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTeamTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTeamTechnology.Response>> Update([FromBody]UpdateTeamTechnology.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{teamTechnologyId}", Name = "RemoveTeamTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTeamTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTeamTechnology.Response>> Remove([FromRoute]RemoveTeamTechnology.Request request)
            => await _mediator.Send(request);
        
    }
}
