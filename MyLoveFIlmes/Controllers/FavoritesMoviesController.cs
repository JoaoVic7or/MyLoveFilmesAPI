using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLoveFilmes.Controllers.Shared;
using MyLoveFilmes.Extensions;
using MyLoveFilmes.Shared.Domain.Result;
using MyLoveFilmes.Core.Command.FavoritesMovies;

namespace MyLoveFilmes.Controllers
{
    public class FavoritesMoviesController : BaseController
    {
        public FavoritesMoviesController(IMediator mediator) : base(mediator) { }

        [Authorize]
        [HttpGet("GetFavoritesMoviesByUser")]
        public async Task<IActionResult> GetFavoritesMoviesByUser([FromQuery] GetFavoritesMoviesByUserCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize]
        [HttpPost("InsertFavoriteMovie")]
        public async Task<IActionResult> InsertFavoriteMovieAsync([FromQuery] InsertFavoriteMovieCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }

        [Authorize]
        [HttpDelete("DeleteFavoriteMovie")]
        public async Task<IActionResult> DeleteFavoriteMovieAsync([FromQuery] DeleteFavoriteMovieCommand command)
        {
            Result result = await _mediator.Send(command);

            return ResultHelper.AsResult(result);
        }
    }
}
