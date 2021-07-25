using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficeController
    {
        private readonly IMediator _mediator;

        public OfficeController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{officeId}", Name = "GetOfficeByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOfficeById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOfficeById.Response>> GetById([FromRoute]GetOfficeById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Office == null)
            {
                return new NotFoundObjectResult(request.OfficeId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetOfficesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOffices.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOffices.Response>> Get()
            => await _mediator.Send(new GetOffices.Request());
        
        [HttpPost(Name = "CreateOfficeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateOffice.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateOffice.Response>> Create([FromBody]CreateOffice.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetOfficesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOfficesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetOfficesPage.Response>> Page([FromRoute]GetOfficesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateOfficeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateOffice.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateOffice.Response>> Update([FromBody]UpdateOffice.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{officeId}", Name = "RemoveOfficeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveOffice.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveOffice.Response>> Remove([FromRoute]RemoveOffice.Request request)
            => await _mediator.Send(request);
        
    }
}
