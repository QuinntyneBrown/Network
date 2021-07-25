using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationTechnologyController
    {
        private readonly IMediator _mediator;

        public OrganizationTechnologyController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{organizationTechnologyId}", Name = "GetOrganizationTechnologyByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationTechnologyById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationTechnologyById.Response>> GetById([FromRoute]GetOrganizationTechnologyById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.OrganizationTechnology == null)
            {
                return new NotFoundObjectResult(request.OrganizationTechnologyId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetOrganizationTechnologiesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationTechnologies.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationTechnologies.Response>> Get()
            => await _mediator.Send(new GetOrganizationTechnologies.Request());
        
        [HttpPost(Name = "CreateOrganizationTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateOrganizationTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateOrganizationTechnology.Response>> Create([FromBody]CreateOrganizationTechnology.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetOrganizationTechnologiesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationTechnologiesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationTechnologiesPage.Response>> Page([FromRoute]GetOrganizationTechnologiesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateOrganizationTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateOrganizationTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateOrganizationTechnology.Response>> Update([FromBody]UpdateOrganizationTechnology.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{organizationTechnologyId}", Name = "RemoveOrganizationTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveOrganizationTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveOrganizationTechnology.Response>> Remove([FromRoute]RemoveOrganizationTechnology.Request request)
            => await _mediator.Send(request);
        
    }
}
