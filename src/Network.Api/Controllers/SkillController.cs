using System.Net;
using System.Threading.Tasks;
using Network.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Network.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{skillId}", Name = "GetSkillByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSkillById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSkillById.Response>> GetById([FromRoute]GetSkillById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Skill == null)
            {
                return new NotFoundObjectResult(request.SkillId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetSkillsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSkills.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSkills.Response>> Get()
            => await _mediator.Send(new GetSkills.Request());
        
        [HttpPost(Name = "CreateSkillRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateSkill.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSkill.Response>> Create([FromBody]CreateSkill.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetSkillsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetSkillsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetSkillsPage.Response>> Page([FromRoute]GetSkillsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateSkillRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateSkill.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateSkill.Response>> Update([FromBody]UpdateSkill.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{skillId}", Name = "RemoveSkillRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveSkill.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveSkill.Response>> Remove([FromRoute]RemoveSkill.Request request)
            => await _mediator.Send(request);
        
    }
}
