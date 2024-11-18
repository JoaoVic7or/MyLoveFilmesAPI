using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;
using MyLoveFilmes.Core.Command.Users;
using MyLoveFilmes.Extensions;
using MyLoveFilmes.Shared.Domain.Result;
using Microsoft.AspNetCore.Authorization;

namespace MyLoveFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize]
        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }
    }
}
