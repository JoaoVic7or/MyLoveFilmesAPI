using MediatR;
using MyLoveFilmes.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Core.Command.WatchsLists;
using MyLoveFilmes.Shared.Domain.Result;
using MyLoveFilmes.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace MyLoveFilmes.Controllers
{
    public class WatchListController : BaseController
    {
        public WatchListController(IMediator mediator) : base(mediator) { }

        [Authorize]
        [HttpGet("GetWatchListByUser")]
        public async Task<IActionResult> GetWatchListByUser([FromQuery] GetWatchListByUserCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize]
        [HttpPost("InsertMovieWatchList")]
        public async Task<IActionResult> InsertWatchListAsync([FromBody] InsertMovieWatchListCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize]
        [HttpDelete("DeleteMovieFromWatchList")]
        public async Task<IActionResult> DeleteMovieFromWatchListAsync([FromBody] DeleteMovieFromWatchListCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }
    }
}
