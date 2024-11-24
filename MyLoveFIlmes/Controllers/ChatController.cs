using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;
using MyLoveFilmes.Core.Command.Messages;
using MyLoveFilmes.Extensions;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : BaseController
	{
		public ChatController(IMediator mediator) : base(mediator) { }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(SendMessageCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }
 	}
}

