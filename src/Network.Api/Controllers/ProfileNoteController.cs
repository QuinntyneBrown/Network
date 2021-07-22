using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileNoteController
    {
        private readonly IMediator _mediator;

        public ProfileNoteController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{profileNoteId}", Name = "GetProfileNoteByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileNoteById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileNoteById.Response>> GetById([FromRoute]GetProfileNoteById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.ProfileNote == null)
            {
                return new NotFoundObjectResult(request.ProfileNoteId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetProfileNotesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileNotes.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileNotes.Response>> Get()
            => await _mediator.Send(new GetProfileNotes.Request());
        
        [HttpPost(Name = "CreateProfileNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateProfileNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateProfileNote.Response>> Create([FromBody]CreateProfileNote.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetProfileNotesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetProfileNotesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfileNotesPage.Response>> Page([FromRoute]GetProfileNotesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateProfileNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateProfileNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateProfileNote.Response>> Update([FromBody]UpdateProfileNote.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{profileNoteId}", Name = "RemoveProfileNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveProfileNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveProfileNote.Response>> Remove([FromRoute]RemoveProfileNote.Request request)
            => await _mediator.Send(request);
        
    }
}
