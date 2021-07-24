using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{positionId}", Name = "GetPositionByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPositionById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPositionById.Response>> GetById([FromRoute] GetPositionById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Position == null)
            {
                return new NotFoundObjectResult(request.PositionId);
            }

            return response;
        }

        [HttpGet(Name = "GetPositionsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPositions.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPositions.Response>> Get()
            => await _mediator.Send(new GetPositions.Request());

        [HttpPost(Name = "CreatePositionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreatePosition.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePosition.Response>> Create([FromBody] CreatePosition.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetPositionsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetPositionsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetPositionsPage.Response>> Page([FromRoute] GetPositionsPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdatePositionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdatePosition.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdatePosition.Response>> Update([FromBody] UpdatePosition.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{positionId}", Name = "RemovePositionRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemovePosition.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemovePosition.Response>> Remove([FromRoute] RemovePosition.Request request)
            => await _mediator.Send(request);

    }
}
