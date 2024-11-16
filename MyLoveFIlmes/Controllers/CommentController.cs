using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;
using MyLoveFilmes.Core.Command.Comments;
using MyLoveFilmes.Extensions;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        public CommentController(IMediator mediator) : base(mediator)
        { }

        //[Authorize]
        [HttpPost("InsertComment")]
        public async Task<IActionResult> InsertCommentAsync([FromBody] InsertCommentCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        //[Authorize]
        [HttpDelete("DeleteComment")]
        public async Task<IActionResult> DeleteCommentAsync([FromBody] DeleteCommentCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [HttpGet("GetCommentsByUser")]
        public async Task<IActionResult> GetCommentsByUserAsync([FromQuery] GetCommentsByUserCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }
    }
}
