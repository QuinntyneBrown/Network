using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController
    {
        private readonly IMediator _mediator;

        public OrganizationController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{organizationId}", Name = "GetOrganizationByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationById.Response>> GetById([FromRoute]GetOrganizationById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Organization == null)
            {
                return new NotFoundObjectResult(request.OrganizationId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetOrganizationsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizations.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizations.Response>> Get()
            => await _mediator.Send(new GetOrganizations.Request());
        
        [HttpPost(Name = "CreateOrganizationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateOrganization.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateOrganization.Response>> Create([FromBody]CreateOrganization.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetOrganizationsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrganizationsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOrganizationsPage.Response>> Page([FromRoute]GetOrganizationsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateOrganizationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateOrganization.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateOrganization.Response>> Update([FromBody]UpdateOrganization.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{organizationId}", Name = "RemoveOrganizationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveOrganization.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveOrganization.Response>> Remove([FromRoute]RemoveOrganization.Request request)
            => await _mediator.Send(request);
        
    }
}
