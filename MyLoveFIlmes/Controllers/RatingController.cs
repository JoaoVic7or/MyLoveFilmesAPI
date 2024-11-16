using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;
using MyLoveFilmes.Core.Command.Ratings;
using MyLoveFilmes.Domain.Roles;
using MyLoveFilmes.Extensions;
using MyLoveFilmes.Shared.Domain.Result;

namespace MyLoveFilmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : BaseController
    {
        public RatingController(IMediator mediator) : base(mediator) { }

        [Authorize]
        [HttpPost("InsertRating")]
        public async Task<IActionResult> InsertRatingAsync([FromBody] InsertRatingCommand command) 
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize]
        [HttpGet("GetRatingsByUser")]
        public async Task<IActionResult> GetRatingsByUser([FromQuery] GetRatingByUserCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize]
        [HttpGet("GetAllRatingsByUser")]
        public async Task<IActionResult> GetAllRatingsByUser([FromQuery] GetAllRatingsByUserCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }
    }
}
