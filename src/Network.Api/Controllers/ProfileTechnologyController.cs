using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileTechnologyController
    {
        private readonly IMediator _mediator;

        public ProfileTechnologyController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{profileTechnologyId}", Name = "GetProfileTechnologyByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileTechnologyById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileTechnologyById.Response>> GetById([FromRoute]GetProfileTechnologyById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.ProfileTechnology == null)
            {
                return new NotFoundObjectResult(request.ProfileTechnologyId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetProfileTechnologiesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileTechnologies.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileTechnologies.Response>> Get()
            => await _mediator.Send(new GetProfileTechnologies.Request());
        
        [HttpPost(Name = "CreateProfileTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProfileTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProfileTechnology.Response>> Create([FromBody]CreateProfileTechnology.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetProfileTechnologiesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileTechnologiesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileTechnologiesPage.Response>> Page([FromRoute]GetProfileTechnologiesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateProfileTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProfileTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProfileTechnology.Response>> Update([FromBody]UpdateProfileTechnology.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{profileTechnologyId}", Name = "RemoveProfileTechnologyRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProfileTechnology.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProfileTechnology.Response>> Remove([FromRoute]RemoveProfileTechnology.Request request)
            => await _mediator.Send(request);
        
    }
}
