using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController
    {
        private readonly IMediator _mediator;

        public NoteController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{noteId}", Name = "GetNoteByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetNoteById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetNoteById.Response>> GetById([FromRoute] GetNoteById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Note == null)
            {
                return new NotFoundObjectResult(request.NoteId);
            }

            return response;
        }

        [HttpGet(Name = "GetNotesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetNotes.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetNotes.Response>> Get()
            => await _mediator.Send(new GetNotes.Request());

        [HttpPost(Name = "CreateNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateNote.Response>> Create([FromBody] CreateNote.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetNotesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetNotesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetNotesPage.Response>> Page([FromRoute] GetNotesPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateNote.Response>> Update([FromBody] UpdateNote.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{noteId}", Name = "RemoveNoteRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveNote.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveNote.Response>> Remove([FromRoute] RemoveNote.Request request)
            => await _mediator.Send(request);

    }
}
